using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data
{
    class TimeRecord
    {
        public User User { get; set; }
        public DateTime RecordTime { get; set; }
        public TypeOfActivity TypeOfActivity { get; set; }

    }
}
