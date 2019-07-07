using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbLayer.Mapping;

namespace DbLayer
{
    public class AutoMapperDbConfiguration
    {
        public static MapperConfiguration MapperCfg;
        public static IMapper DbMapper { get; private set; }
        public static void Configure()
        {
            MapperCfg = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<PositionProfile>();
                cfg.AddProfile<ActivityTypeProfile>();
                cfg.AddProfile<TimeRecordProfile>();
                cfg.AddProfile<UserRecordProfile>();
                cfg.AddProfile<DepartmentProfile>();
            });

            DbMapper = MapperCfg.CreateMapper();
        }
    }
}
