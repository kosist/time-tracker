using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DbLayer;
using DbLayer.DbRepositories;
using DbLayer.Mapping;

namespace TimeTrackerWeb.Mapping
{
    public class AutoMapperWebConfiguration
    {
        public static MapperConfiguration MapperCfg;
        public static IMapper WebMapper { get; private set; }
        public static void Configure()
        {
            MapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<PositionProfile>();
                cfg.AddProfile<ActivityTypeProfile>();
                cfg.AddProfile<TimeRecordProfile>();
                cfg.AddProfile<UserRecordProfile>();
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<UserDtoProfile>();
                cfg.AddProfile<PositionDtoProfile>();
                cfg.AddProfile<ActivityTypeDtoProfile>();
                cfg.AddProfile<TimeRecordDtoProfile>();
                cfg.AddProfile<UserRecordDtoProfile>();
                cfg.AddProfile<DepartmentDtoProfile>();
            });


            WebMapper = MapperCfg.CreateMapper();
        }
    }
}