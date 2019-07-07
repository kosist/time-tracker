using AutoMapper;
using BaseLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class PositionDtoProfile : Profile
    {
        public PositionDtoProfile()
        {
            CreateMap<PositionDto, Position>();

            CreateMap<Position, PositionDto>();
        }
    }
}
