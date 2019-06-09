using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace TimeTracker.RepositoriesInterfaces
{
    interface ITimeRecordRepository : IRepository<TimeRecord>
    {
        IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime);
        void RemoveLastUserRecord(User user);

    }
}
