using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;
using FileLayer.JsonFileRepositories;
using Xunit;

namespace JsonFileRepositoryTests
{
    public class TimeRecordRepoJsonFileTests : IDisposable
    {
        private TimeRecordRepositoryJsonFile TimeRecordRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting.GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting.GenerateUserB("ElMech", "Engineer");
        private const string JsonFileName = "timeRecords.json";

        public TimeRecordRepoJsonFileTests()
        {
            TimeRecordRepo = new TimeRecordRepositoryJsonFile(JsonFileName);
        }

        private void AddTimeRecords()
        {
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(0, UserA, -1));
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(1, UserA, 0));
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(2, UserA, 0));
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(3, UserB, -2));
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(4, UserB, -1));
            TimeRecordRepo.InsertTimeRecord(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(5, UserB, 0));
        }
        [Fact]
        public void GetTimeRecordByIdTest()
        {
            this.AddTimeRecords();
            var record = TimeRecordRepo.GeTimeRecordById(3);
            Assert.Equal("Will", record.User.Name);
        }

        [Fact]
        public void GetUsersDailyRecords()
        {
            this.AddTimeRecords();
            var records = TimeRecordRepo.GetUserDailyRecords(UserA, DateTime.Today);
            var numberOfEntries = records.Count();
            Assert.Equal(2, numberOfEntries);
            Assert.Collection(records, record => Assert.Equal(1, record.Id),
                record => Assert.Equal(2, record.Id));
        }

        public void Dispose()
        {
            TimeRecordRepo.Dispose();
        }
    }
}
