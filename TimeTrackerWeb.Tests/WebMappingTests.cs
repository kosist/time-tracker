using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeTrackerWeb.Mapping;
using Xunit;

namespace TimeTrackerWeb.Tests
{
    public class WebMappingTests
    {
        [Fact]
        public void TestConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserDtoProfile>();
                cfg.AddProfile<PositionDtoProfile>();
                cfg.AddProfile<ActivityTypeDtoProfile>();
                cfg.AddProfile<TimeRecordDtoProfile>();
                cfg.AddProfile<UserRecordDtoProfile>();
                cfg.AddProfile<DepartmentDtoProfile>();
            });

            config.AssertConfigurationIsValid();
        }
    }
}
