using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesImplementation;

namespace TimeTracker.Testing.FileRepositories
{
    class TestUserRepositoryJsonFile
    {

        public UserRepositoryJsonFile UserRepo { get; }
        private User UserA { get; } = SupportRepositoryJsonFileTesting.GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportRepositoryJsonFileTesting.GenerateUserB("ElMech", "Engineer");
        public TestUserRepositoryJsonFile(string userRepoFilePath)
        {
            UserRepo = new UserRepositoryJsonFile(userRepoFilePath);
        }

        private void PrintUsersInfo(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"User info: {user.Name} {user.Surname}, department {user.Department.Name}, works at {user.Position.Name} position");
            }
        }

        public void TestAddAndGetUsers()
        {
            UserRepo.Add(UserA);
            UserRepo.Add(UserB);
            var users = UserRepo.GetAll();
            PrintUsersInfo(users);
        }

        public void TestGetUsersByDepartment()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Test TestGetUsersByDepartment");
            var users = UserRepo.GetUsersOfDepartment(new Department {Name = "ElEng"});
            PrintUsersInfo(users);
        }

    }
}
