using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface IUserReportRepository : IDisposable
    {
        IEnumerable<UserReport> GetUserReports();
        UserReport GetUserReportById(int reportId);
        void InsertUserReport(UserReport report);
        void DeleteUserReport(UserReport report);
        void UpdateUserReport(UserReport report);
        IEnumerable<UserReport> GetMonthlyReports(User user, DateTime month);
        IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate);
        IEnumerable<UserReport> GetYearlyReports(User user, DateTime year);
        IEnumerable<UserReport> GetReportsByTimeRange(User user, DateTime startDate, DateTime endDate);
    }
}
