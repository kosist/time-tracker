using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.DbEntities
{
    [Table("Users")]
    class UserDb
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public virtual DepartmentDb Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual PositionDb Position { get; set; }
        public int PositionId { get; set; }
        [Required]
        [DefaultValue(5)]
        public int NumberOfWorkingDaysPerWeek { get; set; }
        [Required]
        [DefaultValue(8)]
        public float NumberOfDailyWorkHours { get; set; }
        [Required]
        [DefaultValue(60)]
        public int BreakDurationInMinutes { get; set; }
    }
}
