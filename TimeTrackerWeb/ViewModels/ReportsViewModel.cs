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
    }
}