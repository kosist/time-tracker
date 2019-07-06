using System;

namespace TimeTrackerWeb.Dtos
{
    public class TimeRecordDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RecordTime { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
