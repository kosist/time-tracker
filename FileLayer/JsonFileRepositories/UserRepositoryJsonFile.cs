using System.Collections.Generic;
using System.Linq;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using FileLayer.JsonFileRepositories.JsonFileHelpers;

namespace FileLayer.JsonFileRepositories
{
    class UserRepositoryJsonFile : IUserRepository
    {

        protected string FilePath;
        protected JsonFileUserHandler FileHandler;

        public UserRepositoryJsonFile(string filePath)
        {
            FilePath = filePath;
            FileHandler = new JsonFileUserHandler(FilePath);
        }

        #region Interface Implementation

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
            FileHandler.UpdateUser(user);
        }

        public void Dispose()
        {
        }
        #endregion

        #region Specific Methods
        public IEnumerable<User> GetUsersOfDepartment(Department department)
        {
            var usersOfDepartment = GetUsers().Where(u => u.Department.Name == department.Name);
            return usersOfDepartment.ToList();
        } 
        #endregion
    }
}
