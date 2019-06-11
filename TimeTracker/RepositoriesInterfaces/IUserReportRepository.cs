using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace TimeTracker.RepositoriesInterfaces
{
    interface IUserReportRepository : IRepository<UserReport>
    {
        IEnumerable<UserReport> GetMonthlyReports(User user, int monthNumber);
        IEnumerable<UserReport> GetWeeklyReports(User user, DateTime weekStartDate);
        IEnumerable<UserReport> GetYearlyReports(User user, DateTime year);
    }
}
