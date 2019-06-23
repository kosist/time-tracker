using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using FileLayer.JsonFileRepositories.JsonFileHelpers;

namespace FileLayer.JsonFileRepositories
{
    public class UserReportRepositoryJsonFile : IUserReportRepository
    {
        protected string FilePath;
        protected JsonFileUserReportHandler FileHandler;
        public UserReportRepositoryJsonFile(string filePath)
        {
            FilePath = filePath;
            FileHandler = new JsonFileUserReportHandler(filePath);
        }

        #region Interface Implementation
        public UserReport GetUserReportById(int reportId)
        {
            var report = FileHandler.GetObjectById(reportId);
            return report;
        }

        public IEnumerable<UserReport> GetUserReports()
        {
            return FileHandler.GetAllObjects();
        }

        public void InsertUserReport(UserReport report)
        {
            FileHandler.AddObject(report);
        }

        public void UpdateUserReport(UserReport report)
        {
            FileHandler.UpdateUserReport(report);
        }

        public void DeleteUserReport(UserReport report)
        {
            FileHandler.RemoveObject(report);
        }

        public void Dispose()
        {
            FileHandler.DisposeFile();
        } 
        #endregion

        #region Specific Methods
        public IEnumerable<UserReport> GetMonthlyReports(User user, DateTime month)
        {
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == month.Year
                                             && r.Date.Month == month.Month).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate)
        {
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == weekStartDate.Year
                                             && r.Date.DayOfYear >= weekStartDate.DayOfYear
                                             && r.Date.DayOfYear <= weekStartDate.DayOfYear + 7).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetYearlyReports(User user, DateTime year)
        {
            var report = GetUserReports().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == year.Year).ToList();
            return report;
        } 
        #endregion
    }
}
