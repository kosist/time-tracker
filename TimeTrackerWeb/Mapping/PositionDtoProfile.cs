using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class PositionDtoProfile : Profile
    {
        public PositionDtoProfile()
        {
            CreateMap<PositionDto, PositionDb>();

            CreateMap<PositionDb, PositionDto>();
        }
    }
}
