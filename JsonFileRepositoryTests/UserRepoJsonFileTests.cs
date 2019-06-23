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
    public class UserRepoJsonFileTests : IDisposable
    {
        private UserRepositoryJsonFile UserRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting
            .GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting
            .GenerateUserB("ElMech", "Engineer");

        private const string JsonFileName = "users.json";

        public UserRepoJsonFileTests ()
        {
            UserRepo = new UserRepositoryJsonFile(JsonFileName);
        }

        [Fact]
        public void GetUserByIdTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            var user = UserRepo.GetUserById(0);
            Assert.Equal(UserA.Name, user.Name);
        }
        [Fact]
        public void RemoveUserTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            UserRepo.DeleteUser(UserA);
            var users = UserRepo.GetUsers();
            Assert.Single(users);
            Assert.Collection(users, item => Assert.Contains("Will", item.Name));
        }

        [Fact]
        public void UpdateUserTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            UserB.NumberOfDailyWorkHours = 8;
            UserRepo.UpdateUser(UserB);
            // test, if user was really updated
            var user = UserRepo.GetUserById(1);
            Assert.Equal(UserB.NumberOfDailyWorkHours, user.NumberOfDailyWorkHours);
            // test, if no new user was added to file
            var users = UserRepo.GetUsers();
            Assert.Collection(users, 
                item => Assert.Contains("John", item.Name),
                item => Assert.Contains("Will", item.Name));
        }

        [Fact]
        public void GetUserByDepartmentTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            var users = UserRepo.GetUsersOfDepartment(new Department
            {
                Name = "ElEng"
            });
            Assert.Single(users);
            Assert.Collection(users, item => Assert.Contains("John", item.Name));
        }

        public void Dispose()
        {
            UserRepo.Dispose();
        }
    }
}
