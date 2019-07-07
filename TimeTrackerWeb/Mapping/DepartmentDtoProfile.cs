using AutoMapper;
using BaseLayer.DataModels;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.Mapping
{
    public class DepartmentDtoProfile : Profile
    {
        public DepartmentDtoProfile()
        {
            CreateMap<DepartmentDto, Department>();

            CreateMap<Department, DepartmentDto>();
        }
    }
}
