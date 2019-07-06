using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class TimeRecordDtoProfile : Profile
    {
        public TimeRecordDtoProfile()
        {
            CreateMap<TimeRecordDb, TimeRecordDto>();

            CreateMap<TimeRecordDto, TimeRecordDb>()
                .ForMember(r => r.User, opt => opt.Ignore())
                .ForMember(r => r.ActivityType, opt => opt.Ignore());
        }
    }
}
