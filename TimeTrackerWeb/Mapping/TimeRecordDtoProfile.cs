using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class TimeRecordDtoProfile : Profile
    {
        public TimeRecordDtoProfile()
        {
            CreateMap<TimeRecord, TimeRecordDto>()
                .ForMember(r => r.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(r => r.ActivityTypeId, opt => opt.MapFrom(src => src.ActivityType.Id));

            CreateMap<TimeRecordDto, TimeRecord>()
                .ForMember(r => r.User, opt => opt.Ignore())
                .ForMember(r => r.ActivityType, opt => opt.Ignore());
        }
    }
}
