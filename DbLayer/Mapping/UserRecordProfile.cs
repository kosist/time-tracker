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
    class UserRecordProfile : Profile
    {
        public UserRecordProfile()
        {
            CreateMap<UserReportDb, UserReport>();

            CreateMap<UserReport, UserReportDb>()
                .ForMember(u => u.ApprovedByUserId, opt => opt.Ignore())
                .ForMember(u => u.UserId, opt => opt.Ignore());

        }
    }
}
