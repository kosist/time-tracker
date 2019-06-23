using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer.DataModels;

namespace DbLayer.DbRepositories
{
    public class TimeRecordRepositoryDb : ITimeRecordRepository
    {
        private bool _disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<TimeRecordDb> _entities;

        public TimeRecordRepositoryDb(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TimeRecordDb>();
        }

        #region Interface implementation
        public TimeRecord GeTimeRecordById(int recordId)
        {
            var recordDb = _entities.Find(recordId);
            return Mapper.Map<TimeRecordDb, TimeRecord>(recordDb);
        }

        public IEnumerable<TimeRecord> GetTimeRecords()
        {
            return _entities.ToList().Select(Mapper.Map<TimeRecordDb, TimeRecord>);
        }

        public void InsertTimeRecord(TimeRecord record)
        {
            var recordDb = Mapper.Map<TimeRecord, TimeRecordDb>(record);
            _entities.Add(recordDb);
        }

        public void UpdateTimeRecord(TimeRecord record)
        {
            var recordDb = Mapper.Map<TimeRecord, TimeRecordDb>(record);
            Context.Entry(recordDb).State = EntityState.Modified;
        }

        public void DeleteTimeRecord(TimeRecord record)
        {
            var recordDb = Mapper.Map<TimeRecord, TimeRecordDb>(record);
            _entities.Remove(recordDb);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion

        #region Specific methods

        public IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            return _entities
                .Include(r => r.User)
                .Where(r => r.User.Id == userDb.Id && r.RecordTime.Date == dateTime.Date)
                .ToList()
                .Select(Mapper.Map<TimeRecordDb, TimeRecord>);
        }

        public void RemoveLastUserRecord(User user)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            var recordDb = _entities
                .Include(r => r.User)
                .Last(r => r.UserId == userDb.Id);
            _entities.Remove(recordDb);
        } 
        #endregion
    }
}
