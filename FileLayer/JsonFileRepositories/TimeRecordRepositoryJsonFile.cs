using System;
using System.Collections.Generic;
using System.Linq;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using FileLayer.JsonFileRepositories.JsonFileHelpers;

namespace FileLayer.JsonFileRepositories
{
    public class TimeRecordRepositoryJsonFile : ITimeRecordRepository
    {

        protected string FilePath;
        protected JsonFileTimeRecordHandler FileHandler;
        public TimeRecordRepositoryJsonFile(string filePath)
        {
            FilePath = filePath;
            FileHandler = new JsonFileTimeRecordHandler(filePath);
        }

        #region Interface Implementation
        public TimeRecord GeTimeRecordById(int recordId)
        {
            var record = FileHandler.GetObjectById(recordId);
            return record;
        }

        public IEnumerable<TimeRecord> GetTimeRecords()
        {
            var records = FileHandler.GetAllObjects();
            return records;
        }

        public void InsertTimeRecord(TimeRecord record)
        {
            FileHandler.AddObject(record);
        }

        public void UpdateTimeRecord(TimeRecord record)
        {
            FileHandler.UpdateTimeRecord(record);
        }

        public void DeleteTimeRecord(TimeRecord record)
        {
            FileHandler.RemoveObject(record);
        }

        public void Dispose()
        {

        }
        #endregion

        #region Specific Methods
        public IEnumerable<TimeRecord> GetUserDailyRecords(User user, DateTime dateTime)
        {
            var records = GetTimeRecords().Where(rec => rec.User.Name == user.Name
                                                && rec.User.Surname == user.Surname
                                                && rec.RecordTime.Date == dateTime.Date);
            return records;
        }

        public void RemoveLastUserRecord(User user)
        {
            var userLastRecord = GetTimeRecords().Last(rec => rec.User.Name == user.Name
                                                      && rec.User.Surname == user.Surname);
            DeleteTimeRecord(userLastRecord);
        } 
        #endregion

    }
}
