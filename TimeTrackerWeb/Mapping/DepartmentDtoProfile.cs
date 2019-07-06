using AutoMapper;
using DbLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class DepartmentDtoProfile : Profile
    {
        public DepartmentDtoProfile()
        {
            CreateMap<DepartmentDto, DepartmentDb>();

            CreateMap<DepartmentDb, DepartmentDto>();
        }
    }
}
