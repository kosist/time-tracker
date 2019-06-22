using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface IUserReporitory
    {
        IEnumerable<TEntity> GetUsersOfDepartment(Department department);
    }
}
