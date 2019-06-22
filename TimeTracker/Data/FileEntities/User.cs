using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.BaseEntities;

namespace TimeTracker.Data
{
    class User : UserBase
    {
        public Department Department { get; set; }
        public Position Position { get; set; }
        public int NumberOfWorkingDaysPerWeek { get; set; }
        public float NumberOfDailyWorkHours { get; set; }
        public int BreakDurationInMinutes { get; set; }

    }
}
