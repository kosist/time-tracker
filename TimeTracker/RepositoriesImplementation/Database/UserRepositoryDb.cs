using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.DbEntities;
using TimeTracker.RepositoriesInterfaces;

namespace TimeTracker.RepositoriesImplementation.Database
{
    class UserRepositoryDb : RepositoryDb<UserDb>, IUserReporitory
    {
    }
}
