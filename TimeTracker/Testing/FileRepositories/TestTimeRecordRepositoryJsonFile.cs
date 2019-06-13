using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesImplementation;

namespace TimeTracker.Testing.FileRepositories
{
    class TestTimeRecordRepositoryJsonFile
    {
        public TimeRecordRepositoryJsonFile TimeRecordRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting.GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting.GenerateUserB("ElMech", "Engineer");
        public TestTimeRecordRepositoryJsonFile(string userRepoFilePath)
        {
            TimeRecordRepo = new TimeRecordRepositoryJsonFile(userRepoFilePath);
        }

        private void PrintTimeRecordsInfo(IEnumerable<TimeRecord> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"User info: {record.User.Name} {record.User.Surname}, record time {record.RecordTime}, type of activity {record.ActivityType.Name}");
            }
        }

        public void TestAddAndGetTimeRecords()
        {
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserA, -1));
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserA, 0));
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserA, 0));
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserB, -2));
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserB, -1));
            TimeRecordRepo.Add(SupportRepositoryJsonFileTesting.GenerateStartWorkingTimeRecord(UserB, 0));
            var records = TimeRecordRepo.GetAll();
            Console.WriteLine("\n");
            Console.WriteLine("Test add and get records");
            PrintTimeRecordsInfo(records);
        }

        public void TestGetUsersDailyRecords(DateTime dateTime)
        {
            var records = TimeRecordRepo.GetUserDailyRecords(UserA, dateTime);
            Console.WriteLine("\n");
            Console.WriteLine("Test daily report records");
            PrintTimeRecordsInfo(records);
        }

    }
}
