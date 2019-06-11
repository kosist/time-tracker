using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.RepositoriesImplementation;

namespace TimeTracker
{
    class Program
    {
        static void Main(string[] args)
        {

            var depEl = new Department
            {
                Name = "ElectroEng"
            };

            var depMech = new Department
            {
                Name = "MechanicalEng"
            };

            var user1 = new User
            {
                Name = "John",
                Surname = "Wick",
                Department = depEl
            };

            var user2 = new User
            {
                Name = "Will",
                Surname = "Smith",
                Department = depMech
            };

            var user3 = new User
            {
                Name = "Bruce",
                Surname = "Willis"
            };

            RepositoryJsonFile<User> generalUserRepo = new RepositoryJsonFile<User>("testFile.json");
            generalUserRepo.Add(user1);
            generalUserRepo.Add(user2);
            //Console.WriteLine(generalUserRepo.Get(0));
            //Console.WriteLine(userRepo.GetAll());
            var usersCount = generalUserRepo.Find(u => u.Name == "Will").Count();
            Console.WriteLine(usersCount);

            // testing user repositories
            UserRepositoryJsonFile userRepo = new UserRepositoryJsonFile("testFile.json");
            var usersOfDep = userRepo.GetUsersOfDepartment(depMech);
            foreach (var user in usersOfDep)
            {
                Console.WriteLine("User " + user.Name + " " + user.Surname + " works at " + user.Department.Name + " department");
            }
        }
    }
}
