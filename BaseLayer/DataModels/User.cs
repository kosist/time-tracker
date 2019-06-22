using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public int NumberOfWorkingDaysPerWeek { get; set; }
        public float NumberOfDailyWorkHours { get; set; }
        public int BreakDurationInMinutes { get; set; }

    }
}
