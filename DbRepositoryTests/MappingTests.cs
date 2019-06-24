using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbLayer.Mapping;
using Xunit;

namespace DbRepositoryTests
{
    public class MappingTests
    {
        [Fact]
        public void TestConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<PositionProfile>();
                cfg.AddProfile<ActivityTypeProfile>();
                cfg.AddProfile<TimeRecordProfile>();
                cfg.AddProfile<UserRecordProfile>();
                cfg.AddProfile<DepartmentProfile>();
            });

            config.AssertConfigurationIsValid();
        }

        
    }
}
