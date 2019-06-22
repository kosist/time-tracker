using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersOfDepartment(Department department);
        User GetUserById(int userId);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
    }
}
