
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("TimeRecords")]
    public class TimeRecordDb
    {
        public int Id { get; set; }
        public virtual UserDb User { get; set; }
        public int UserId { get; set; }
        public DateTime RecordTime { get; set; }
        public virtual ActivityTypeDb ActivityType { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
