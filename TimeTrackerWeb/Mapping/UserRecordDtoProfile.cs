using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class UserRecordDtoProfile : Profile
    {
        public UserRecordDtoProfile()
        {
            CreateMap<UserReportDb, UserReportDto>();

            CreateMap<UserReportDto, UserReportDb>()
                .ForMember(u => u.User, opt => opt.Ignore())
                .ForMember(u => u.ApprovedByUser, opt => opt.Ignore());

        }
    }
}
