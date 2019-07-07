using AutoMapper;
using BaseLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class UserRecordDtoProfile : Profile
    {
        public UserRecordDtoProfile()
        {
            CreateMap<UserReport, UserReportDto>()
                .ForMember(u => u.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(u => u.ApprovedByUserId, opt => opt.MapFrom(src => src.ApprovedByUser.Id));

            CreateMap<UserReportDto, UserReport>()
                .ForMember(u => u.User, opt => opt.Ignore())
                .ForMember(u => u.ApprovedByUser, opt => opt.Ignore());

        }
    }
}
