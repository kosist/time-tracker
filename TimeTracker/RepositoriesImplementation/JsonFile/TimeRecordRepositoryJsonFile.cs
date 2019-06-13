using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesInterfaces;

namespace TimeTracker.RepositoriesImplementation
{
    class TimeRecordRepositoryJsonFile : RepositoryJsonFile<TimeRecord>, ITimeRecordRepository
    {
        public TimeRecordRepositoryJsonFile(string filePath) : base(filePath)
        {

        }

        public IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime)
        {
            var records = GetAll().Where(rec => rec.User.Name == user.Name
                                                && rec.User.Surname == user.Surname
                                                && rec.RecordTime.Date == dateTime.Date);
            return records;
        }

        public void RemoveLastUserRecord(User user)
        {
            var userLastRecord = GetAll().Last(rec => rec.User.Name == user.Name 
                                                      && rec.User.Surname == user.Surname);
            Remove(userLastRecord);
        }
    }
}
