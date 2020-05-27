using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.ViewModels
{
    public class ReportsViewModel
    {
        public IEnumerable<UserReportDto> Reports { get; set; }
        public UserDto User { get; set; }
        public UserDto UserLead { get; set; }
        public IEnumerable<UserDto> UsersLeads { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}