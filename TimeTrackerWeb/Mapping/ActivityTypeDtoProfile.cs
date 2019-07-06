using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class ActivityTypeDtoProfile : Profile
    {
        public ActivityTypeDtoProfile()
        {
            CreateMap<ActivityTypeDto, ActivityTypeDb>();

            CreateMap<ActivityTypeDb, ActivityTypeDto>();
        }
    }
}
