using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesImplementation;

namespace TimeTracker.Testing.FileRepositories
{
    class TestUserReportRepositoryJsonFile
    {
        public UserReportRepositoryJsonFile UserReportsRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting.GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting.GenerateUserB("ElMech", "Engineer");
        public TestUserReportRepositoryJsonFile(string userRepoFilePath)
        {
            UserReportsRepo = new UserReportRepositoryJsonFile(userRepoFilePath);
        }

        private void PrintUserReportInfo(IEnumerable<UserReport> userReports)
        {
            foreach (var userReport in userReports)
            {
                Console.WriteLine($"User report: {userReport.User.Name} {userReport.User.Surname}, {userReport.Date}");
            }
        }

        public void TestAddAndGetUserReport()
        {
            var userReports = new List<UserReport>();
            var userAJanuaryReports = SupportRepositoryJsonFileTesting
                               .GenerateUserWeeklyReportRecords(UserA, new DateTime(2019, 1, 1));
            userReports.AddRange(userAJanuaryReports);
            var userAFebruaryReports = SupportRepositoryJsonFileTesting
                               .GenerateUserWeeklyReportRecords(UserA, new DateTime(2019, 2, 1));
            userReports.AddRange(userAFebruaryReports);
            var userBJanuaryReports = SupportRepositoryJsonFileTesting
                .GenerateUserWeeklyReportRecords(UserB, new DateTime(2018, 1, 1));
            userReports.AddRange(userBJanuaryReports);
            var userBFebruaryReports = SupportRepositoryJsonFileTesting
                .GenerateUserWeeklyReportRecords(UserB, new DateTime(2018, 2, 1));
            userReports.AddRange(userBFebruaryReports);
            var userBMarchReports = SupportRepositoryJsonFileTesting
                .GenerateUserWeeklyReportRecords(UserB, new DateTime(2019, 3, 1));
            userReports.AddRange(userBMarchReports);

            foreach (var userReport in userReports)
            {
                UserReportsRepo.Add(userReport);
            }

            var records = UserReportsRepo.GetAll();
            Console.WriteLine("\n");
            Console.WriteLine("Test add and get user reports");
            PrintUserReportInfo(records);
        }

        public void TestGetWeeklyUserReport()
        {
            //not good, because relies on previous test method
            var records = UserReportsRepo.GetWeeklyReports(UserA, new DateTime(2019, 1, 1));
            Console.WriteLine("\n");
            Console.WriteLine("Test GetWeekly user reports");
            PrintUserReportInfo(records);
        }
        public void TestGetMonthlyUserReport()
        {
            //not good, because relies on previous test method
            var records = UserReportsRepo.GetMonthlyReports(UserB, new DateTime(2019, 3, 1));
            Console.WriteLine("\n");
            Console.WriteLine("Test GetMonthly user reports");
            PrintUserReportInfo(records);
        }
        public void TestGetYearlyUserReport()
        {
            //not good, because relies on previous test method
            var records = UserReportsRepo.GetYearlyReports(UserB, new DateTime(2018, 1, 1));
            Console.WriteLine("\n");
            Console.WriteLine("Test GetYearly user reports");
            PrintUserReportInfo(records);
        }
    }
}
