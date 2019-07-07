using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TimeTrackerWeb.Mapping
{
    public class AutoMapperWebConfiguration
    {
        public static MapperConfiguration MapperCfg;
        public static void Configure()
        {
            MapperCfg = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserDtoProfile>();
                cfg.AddProfile<PositionDtoProfile>();
                cfg.AddProfile<ActivityTypeDtoProfile>();
                cfg.AddProfile<TimeRecordDtoProfile>();
                cfg.AddProfile<UserRecordDtoProfile>();
                cfg.AddProfile<DepartmentDtoProfile>();
            });
        }
    }
}