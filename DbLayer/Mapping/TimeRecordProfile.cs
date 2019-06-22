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
    class TimeRecordProfile : Profile
    {
        public TimeRecordProfile()
        {
            CreateMap<TimeRecordDb, TimeRecord>();

            CreateMap<TimeRecord, TimeRecordDb>()
                .ForMember(r => r.UserId, opt => opt.Ignore())
                .ForMember(r => r.ActivityTypeId, opt => opt.Ignore());
        }
    }
}
