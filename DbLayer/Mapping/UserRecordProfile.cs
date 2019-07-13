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
    public class UserRecordProfile : Profile
    {
        public UserRecordProfile()
        {
            CreateMap<UserReportDb, UserReport>()
                .ForMember(u => u.ApprovedByUser, opt => opt.MapFrom(src => src.ApprovedByUser));

            CreateMap<UserReport, UserReportDb>()
                .ForMember(u => u.ApprovedByUserId, opt => opt.MapFrom(src => src.ApprovedByUser.Id))
                .ForMember(u => u.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(u => u.User, opt => opt.Ignore())
                .ForMember(u => u.ApprovedByUser, opt => opt.Ignore());

        }
    }
}
