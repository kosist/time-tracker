using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public int NumberOfWorkingDays { get; set; }
        public float NumberOfDailyWorkHours { get; set; }
        public int BreakDurationInMinutes { get; set; }

    }
}
