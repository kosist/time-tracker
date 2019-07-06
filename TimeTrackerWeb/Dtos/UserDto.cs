using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTrackerWeb.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int DepartmentId { get; set; }
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

        public string FullName => Name + " " + Surname;
    }
}