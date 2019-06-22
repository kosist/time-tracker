using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer.DataModels;

namespace DbLayer.DbRepositories
{
    public class TimeRecordRepositoryDb : ITimeRecordRepository
    {
        private bool disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<TimeRecord> Entities;

        public TimeRecordRepositoryDb(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TimeRecord>();
        }

        public TimeRecord GeTimeRecordById(int recordId)
        {
            return Entities.Find(recordId);
        }

        public IEnumerable<TimeRecord> GetTimeRecords()
        {
            return Entities.ToList();
        }

        public void InsertTimeRecord(TimeRecord record)
        {
            Entities.Add(record);
        }

        public void UpdateTimeRecord(TimeRecord record)
        {
            Context.Entry(record).State = EntityState.Modified;
        }

        public void DeleteTimeRecord(TimeRecord record)
        {
            Entities.Remove(record);
        }

        public void DeleteUser(User user)
        {
            Entities.Remove(user);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime)
        {
            return Entities
                .Include(r => r.User)
                .Where(r => r.User.Id == user.Id && r.RecordTime.Date == dateTime.Date)
                .ToList();
        }

        public void RemoveLastUserRecord(User user)
        {
            TimeRecordDb
        }

    }
}
