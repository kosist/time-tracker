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
    public class UserReportRepositoryDb : IUserReportRepository
    {
        private bool _disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<UserReportDb> _entities;

        public UserReportRepositoryDb(DbContext context)
        {
            Context = context;
            _entities = Context.Set<UserReportDb>();
        }

        #region Interface implementation
        public UserReport GetUserReportById(int reportId)
        {
            var userReportDb = _entities.Find(reportId);
            return Mapper.Map<UserReportDb, UserReport>(userReportDb);
        }

        public IEnumerable<UserReport> GetUserReports()
        {
            return _entities.ToList().Select(Mapper.Map<UserReportDb, UserReport>);
        }

        public void InsertUserReport(UserReport report)
        {
            var userReportDb = Mapper.Map<UserReport, UserReportDb>(report);
            _entities.Add(userReportDb);
        }

        public void UpdateUserReport(UserReport report)
        {
            var userReportDb = Mapper.Map<UserReport, UserReportDb>(report);
            Context.Entry(userReportDb).State = EntityState.Modified;
        }

        public void DeleteUserReport(UserReport report)
        {
            var userReportDb = Mapper.Map<UserReport, UserReportDb>(report);
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
            var userDb = Mapper.Map<User, UserDb>(user);
            var reports = GetUserReports().Where(r => r.User.Name == userDb.Name
                                                     && r.User.Surname == userDb.Surname
                                                     && r.Date.Year == month.Year
                                                     && r.Date.Month == month.Month).ToList();
            return reports;
        }

        public IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                                     && r.User.Surname == user.Surname
                                                     && r.Date.Year == weekStartDate.Year
                                                     && r.Date.DayOfYear >= weekStartDate.DayOfYear
                                                     && r.Date.DayOfYear <= weekStartDate.DayOfYear + 7).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetYearlyReports(User user, DateTime year)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                                     && r.User.Surname == user.Surname
                                                     && r.Date.Year == year.Year).ToList();
            return report;
        } 
        #endregion
    }
}
