using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DataModels;

namespace DbLayer.Mapping
{
    public class ActivityTypeProfile : Profile
    {
        public ActivityTypeProfile()
        {
            CreateMap<ActivityType, ActivityTypeDb>();

            CreateMap<ActivityTypeDb, ActivityType>();
        }
    }
}
