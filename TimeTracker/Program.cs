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
            var user1 = new User
            {
                Name = "John",
                Surname = "Wick"
            };

            var user2 = new User
            {
                Name = "Will",
                Surname = "Smith"
            };

            var user3 = new User
            {
                Name = "Bruce",
                Surname = "Willis"
            };

            RepositoryJsonFile<User> userRepo = new RepositoryJsonFile<User>("testFile.json");
            userRepo.Add(user1);
            userRepo.Add(user2);
            //Console.WriteLine(userRepo.Get(0).Name);
            Console.WriteLine(userRepo.GetAll());


        }
    }
}
