using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("UserReports")]
    public class UserReportDb
    {
        public int Id { get; set; }
        public virtual UserDb User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double WorkHours { get; set; }
        public double BreakHours { get; set; }
        public double TimeDifference { get; set; }
        public string TimeDifferenceReason { get; set; }
        public virtual UserDb ApprovedByUser { get; set; }
        public int? ApprovedByUserId { get; set; } 
        public bool ApprovedFlag { get; set; }
    }
}
