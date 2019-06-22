using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TimeTracker.Data;

namespace TimeTracker.RepositoriesInterfaces
{
    interface IUserReporitory : IRepository<TEntity>
    {
        IEnumerable<TEntity> GetUsersOfDepartment(Department department);
    }
}
