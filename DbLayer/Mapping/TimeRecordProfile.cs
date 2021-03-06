﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DataModels;

namespace DbLayer.Mapping
{
    public class TimeRecordProfile : Profile
    {
        public TimeRecordProfile()
        {
            CreateMap<TimeRecordDb, TimeRecord>();

            CreateMap<TimeRecord, TimeRecordDb>()
                .ForMember(r => r.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(r => r.ActivityTypeId, opt => opt.MapFrom(src => src.ActivityType.Id))
                .ForMember(r => r.User, opt => opt.Ignore())
                .ForMember(r => r.ActivityType, opt => opt.Ignore());
        }
    }
}
