using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace TimeTracker.RepositoriesInterfaces
{
    interface IUserReporitory : IRepository<User>
    {
        IEnumerable<User> GetUsersOfDepartment(Department department);
    }
}
