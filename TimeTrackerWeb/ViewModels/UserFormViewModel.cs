using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.ViewModels
{
    public class UserFormViewModel
    {
        public UserDto User { get; set; }
        public IEnumerable<DepartmentDto> Departments { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}