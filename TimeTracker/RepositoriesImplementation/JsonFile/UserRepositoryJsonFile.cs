using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.BaseEntities;
using TimeTracker.RepositoriesInterfaces;

namespace TimeTracker.RepositoriesImplementation
{
    class UserRepositoryJsonFile : RepositoryJsonFile<UserBase>, IUserReporitory
    {
        private IUserReporitory _userReporitoryImplementation;

        public UserRepositoryJsonFile(string filePath) : base(filePath)
        {
        }

        public IEnumerable<User> GetUsersOfDepartment(Department department)
        {
            var usersOfDepartment = GetAll().Where(u => u.Department.Name == department.Name);
            return usersOfDepartment.ToList();
        }
    }
}
