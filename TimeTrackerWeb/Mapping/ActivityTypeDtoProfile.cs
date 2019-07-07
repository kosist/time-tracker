using AutoMapper;
using BaseLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class ActivityTypeDtoProfile : Profile
    {
        public ActivityTypeDtoProfile()
        {
            CreateMap<ActivityTypeDto, ActivityType>();

            CreateMap<ActivityType, ActivityTypeDto>();
        }
    }
}
