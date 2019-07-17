using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<UserDto> Users { get; set; }
        public UserDto User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}