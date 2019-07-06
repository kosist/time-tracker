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
        public float WorkHours { get; set; }
        public float BreakHours { get; set; }
        public float TimeDifference { get; set; }
        public string TimeDifferenceReason { get; set; }
        public int ApprovedByUserId { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}