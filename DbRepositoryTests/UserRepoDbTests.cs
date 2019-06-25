using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer;
using DbLayer.DbRepositories;
using DbLayer.Mapping;
using Xunit;

namespace DbRepositoryTests
{
    public class UserRepoDbTests : IDisposable
    {
        private readonly UnitOfWork manager;
        private readonly IUserRepository UserRepo;
        private User UserA { get; } = SupportDbTesting
            .GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportDbTesting
            .GenerateUserB("ElMech", "Engineer");

        public UserRepoDbTests()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var testContext = new TimeTrackerDbContext(connection);
            manager = new UnitOfWork(testContext);
            UserRepo = manager.Users;
        }

        [Fact]
        public void GetUserByIdTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            manager.Complete();
            var user = UserRepo.GetUserById(0);
            Assert.Equal(UserA.Name, user.Name);
        }
        [Fact]
        public void RemoveUserTest()
        {
            UserRepo.InsertUser(UserA);
            UserRepo.InsertUser(UserB);
            UserRepo.DeleteUser(UserA);
            manager.Complete();
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
            manager.Complete();
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
            manager.Complete();
            var users = UserRepo.GetUsersOfDepartment(new Department
            {
                Name = "ElEng"
            });
            Assert.Single(users);
            Assert.Collection(users, item => Assert.Contains("John", item.Name));
        }


        public void Dispose()
        {
            manager.Dispose();
        }
    }
}
