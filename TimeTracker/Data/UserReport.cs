﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data
{
    class UserReport
    {
        public User User { get; set; }
        public DateTime Date { get; set; }
        public float WorkHours { get; set; }
        public float BreakHours { get; set; }
        public float TimeDifference { get; set; }
        public string TimeDifferenceReason { get; set; }
        public User ApprovedBy { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}