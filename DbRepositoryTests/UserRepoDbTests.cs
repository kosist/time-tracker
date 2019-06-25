using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;
using DbLayer;
using DbLayer.DbRepositories;
using Xunit;

namespace DbRepositoryTests
{
    class UserRepoDbTests : IDisposable
    {
        private readonly UserRepositoryDb UserRepo;
        private User UserA { get; } = SupportDbTesting
            .GenerateUserA("ElEng", "Engineer");
        private User UserB { get; } = SupportDbTesting
            .GenerateUserB("ElMech", "Engineer");

        public UserRepoDbTests()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var _testContext = new TimeTrackerDbContext(connection);
            UserRepo = new UserRepositoryDb(_testContext);

        }

       

        public void Dispose()
        {
            UserRepo.Dispose();
        }
    }
}
