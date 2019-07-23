using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrackerWeb.Dtos
{
    public class UserReportDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double WorkHours { get; set; }
        public double BreakHours { get; set; }
        public double TimeDifference { get; set; }
        public string TimeDifferenceReason { get; set; }
        public int ApprovedByUserId { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}