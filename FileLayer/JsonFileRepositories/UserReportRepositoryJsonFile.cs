using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesInterfaces;

namespace TimeTracker.RepositoriesImplementation
{
    class UserReportRepositoryJsonFile : RepositoryJsonFile<UserReport>, IUserReportRepository
    {

        public UserReportRepositoryJsonFile(string filePath) : base(filePath)
        {
        }

        public IEnumerable<UserReport> GetMonthlyReports(User user, DateTime month)
        {
            var report = GetAll().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == month.Year
                                             && r.Date.Month == month.Month).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate)
        {
            var report = GetAll().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == weekStartDate.Year
                                             && r.Date.DayOfYear >= weekStartDate.DayOfYear
                                             && r.Date.DayOfYear <= weekStartDate.DayOfYear + 7).ToList();
            return report;
        }

        public IEnumerable<UserReport> GetYearlyReports(User user, DateTime year)
        {
            var report = GetAll().Where(r => r.User.Name == user.Name
                                             && r.User.Surname == user.Surname
                                             && r.Date.Year == year.Year).ToList();
            return report;
        }
    }
}
