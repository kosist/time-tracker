using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.DataModels
{
    public class UserReport
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double WorkHours { get; set; }
        public double BreakHours { get; set; }
        public double TimeDifference { get; set; }
        public string TimeDifferenceReason { get; set; }
        public User ApprovedByUser { get; set; }
        public bool ApprovedFlag { get; set; }


    }
}
