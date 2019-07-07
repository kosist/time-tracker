using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.Mapping;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.DepartmentId, opt => opt.MapFrom(src => src.Department.Id))
                .ForMember(u => u.PositionId, opt => opt.MapFrom(src => src.Position.Id));

            CreateMap<UserDto, User>()
                .ForMember(u => u.Department, opt => opt.Ignore())
                .ForMember(u => u.Position, opt => opt.Ignore());
        }
    }
}
