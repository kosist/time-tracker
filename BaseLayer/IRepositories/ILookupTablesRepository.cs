using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;

namespace BaseLayer.IRepositories
{
    public interface ILookupTablesRepository : IDisposable
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Position> GetPositions();
        IEnumerable<ActivityType> GetActivityTypes();

    }
}
