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
    public class UserReportRepoJsonFileTests : IDisposable
    {
        private UserReportRepositoryJsonFile UserReportsRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting.GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting.GenerateUserB("ElMech", "Engineer");
        private const string JsonFileName = "userReports.json";

        public UserReportRepoJsonFileTests()
        {
            UserReportsRepo = new UserReportRepositoryJsonFile(JsonFileName);
        }

        // helper method, in order to generate reports
        private void GenerateUserReports()
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

            int counter = 0;
            foreach (var userReport in userReports)
            {
                userReport.Id = counter;
                UserReportsRepo.InsertUserReport(userReport);
                counter++;
            }
        }

        [Fact]
        public void GetUserReportByIdTest()
        {
            this.GenerateUserReports();
            var report = UserReportsRepo.GetUserReportById(14);
            Assert.Equal(2018, report.Date.Year);
            Assert.Equal(1, report.Date.Month);
            Assert.Equal(1, report.Date.Day);
        }

        [Fact]
        public void GetUserWeeklyReportTest()
        {
            this.GenerateUserReports();
            var records = UserReportsRepo.GetWeeklyReports(UserA, new DateTime(2019, 1, 1));
            Assert.All(records, 
                item => Assert.Equal("John", item.User.Name));
            Assert.All(records, 
                item => Assert.Equal(2019, item.Date.Year));
            Assert.All(records, 
                item => Assert.Equal(1, item.Date.Month));
        }

        [Fact]
        public void GetUserMonthlyReportTest()
        {
            this.GenerateUserReports();
            var records = UserReportsRepo.GetMonthlyReports(UserB, new DateTime(2019, 3, 1));
            Assert.All(records, 
                item => Assert.Equal("Will", item.User.Name));
            Assert.All(records, 
                item => Assert.Equal(2019, item.Date.Year));
            Assert.All(records, 
                item => Assert.Equal(3, item.Date.Month));
        }

        [Fact]
        public void GetUserYearlyReportTest()
        {
            this.GenerateUserReports();
            var records = UserReportsRepo.GetYearlyReports(UserB, new DateTime(2018, 1, 1));
            Assert.All(records, 
                item => Assert.Equal("Will", item.User.Name));
            Assert.All(records, 
                item => Assert.Equal(2018, item.Date.Year));
        }

        public void Dispose()
        {
            UserReportsRepo.Dispose();
        }
    }
}
