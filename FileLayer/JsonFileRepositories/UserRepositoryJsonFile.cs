using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using FileLayer;

namespace TimeTracker.RepositoriesImplementation
{
    class UserRepositoryJsonFile : IUserRepository
    {

        protected string FilePath;
        protected JsonFileHandler<User> FileHandler;

        public UserRepositoryJsonFile(string filePath)
        {
            FilePath = filePath;
            FileHandler = new JsonFileHandler<User>(FilePath);
        }

        public User GetUserById(int userId)
        {
            var user = FileHandler.GetObjectById(userId);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = FileHandler.GetAllObjects();
            return users;
        }

        public void InsertUser(User user)
        {
            FileHandler.AddObject(user);
        }

        public void DeleteUser(User user)
        {
            FileHandler.RemoveObject(user);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public IEnumerable<User> GetUsersOfDepartment(Department department)
        {
            var usersOfDepartment = GetUsers().Where(u => u.Department.Name == department.Name);
            return usersOfDepartment.ToList();
        }
    }
}
