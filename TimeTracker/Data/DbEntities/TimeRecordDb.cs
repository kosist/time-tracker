using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.DbEntities
{
    [Table("TimeRecords")]
    class TimeRecordDb
    {
        public int Id { get; set; }
        public virtual UserDb User { get; set; }
        public int UserId { get; set; }
        public DateTime RecordTime { get; set; }
        public virtual ActivityTypeDb ActivityType { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
