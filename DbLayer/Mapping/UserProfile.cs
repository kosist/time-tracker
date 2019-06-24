using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DataModels;

namespace DbLayer.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDb, User>();

            CreateMap<User, UserDb>()
                .ForMember(u => u.DepartmentId, opt => opt.Ignore())
                .ForMember(u => u.PositionId, opt => opt.Ignore());
        }
    }
}
