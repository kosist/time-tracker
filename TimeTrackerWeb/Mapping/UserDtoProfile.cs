using System.EnterpriseServices;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DbRepositories;
using DbLayer.Mapping;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
        }
    }
}
