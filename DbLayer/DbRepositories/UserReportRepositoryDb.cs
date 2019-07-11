using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer.DataModels;

namespace DbLayer.DbRepositories
{
    public class UserReportRepositoryDb : IUserReportRepository
    {
        private bool _disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<UserReportDb> _entities;
        private readonly IMapper _mapper;

        public UserReportRepositoryDb(DbContext context, IMapper mapper)
        {
            Context = context;
            _entities = Context.Set<UserReportDb>();
            _mapper = mapper;
        }

        #region Interface implementation
        public UserReport GetUserReportById(int reportId)
        {
            var userReportDb = _entities
                .Include(rec => rec.User)
                .Include(rec => rec.ApprovedByUser)
                .SingleOrDefault(rec => rec.Id == reportId);
            return _mapper.Map<UserReportDb, UserReport>(userReportDb);
        }

        public IEnumerable<UserReport> GetUserReports()
        {
            return _entities
                .Include(rec => rec.User)
                .Include(rec => rec.ApprovedByUser)
                .ToList()
                .Select(_mapper.Map<UserReportDb, UserReport>);
        }

        public void InsertUserReport(UserReport report)
        {
            var userReportDb = _mapper.Map<UserReport, UserReportDb>(report);
            _entities.Add(userReportDb);
        }

        public void UpdateUserReport(UserReport report)
        {
            var userReportDb = _mapper.Map<UserReport, UserReportDb>(report);
            _entities.AddOrUpdate(userReportDb);
        }

        public void DeleteUserReport(UserReport report)
        {
            var userReportDb = _mapper.Map<UserReport, UserReportDb>(report);
            _entities.Remove(userReportDb);
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
        public IEnumerable<UserReport> GetMonthlyReports(User user, DateTime month)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            var reports = GetUserReports().Where(r => r.User.Name == userDb.Name
                                                     && r.User.Surname == userDb.Surname
                                                     && r.Date.Year == month.Year
                                                     && r.Date.Month == month.Month).ToList();
            return reports;
        }

        public IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                                     && r.User.Surname == user.Surname
                                                     && r.Date.Year == weekStartDate.Year
                                                     && r.Date.DayOfYear >= weekStartDate.DayOfYear
                                                     && r.Date.DayOfYear <= weekStartDate.DayOfYear + 7).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetYearlyReports(User user, DateTime year)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                                     && r.User.Surname == user.Surname
                                                     && r.Date.Year == year.Year).ToList();
            return report;
        } 
        #endregion
    }
}
