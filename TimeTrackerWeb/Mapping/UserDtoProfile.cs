using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserDb, UserDto>();

            CreateMap<UserDto, UserDb>()
                .ForMember(u => u.Department, opt => opt.Ignore())
                .ForMember(u => u.Position, opt => opt.Ignore());
        }
    }
}
