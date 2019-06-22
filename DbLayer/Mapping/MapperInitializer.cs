using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DbLayer.Mapping
{
    public class MapperInitializer
    {
        [Obsolete]
        public MapperInitializer()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<TimeRecordProfile>();
                cfg.AddProfile<UserRecordProfile>();
                cfg.AddProfile<DepartmentProfile>();
            });
        }
    }
}
