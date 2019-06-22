using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.DataModels
{
    public class TimeRecord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime RecordTime { get; set; }
        public ActivityType ActivityType { get; set; }

    }
}
