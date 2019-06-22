using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface ITimeRecordRepository
    {
        IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime);
        void RemoveLastUserRecord(User user);

    }
}
