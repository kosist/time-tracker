using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface ITimeRecordRepository : IDisposable
    {
        IEnumerable<TimeRecord> GetTimeRecords();
        TimeRecord GeTimeRecordById(int recordId);
        void InsertTimeRecord(TimeRecord record);
        void DeleteTimeRecord(TimeRecord record);
        void UpdateTimeRecord(TimeRecord record);
        IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime);
        void RemoveLastUserRecord(User user);
    }
}
