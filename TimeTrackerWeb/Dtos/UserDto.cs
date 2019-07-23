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

        [DisplayName("Departments List")]
        public DepartmentDto Department { get; set; }

        [DisplayName("Positions List")]
        public PositionDto Position { get; set; }

        [Required]
        [DefaultValue(5)]
        [DisplayName("Number of working days per week")]
        public int NumberOfWorkingDaysPerWeek { get; set; }

        [Required]
        [DefaultValue(8)]
        [DisplayName("Number of daily work hours")]
        public float NumberOfDailyWorkHours { get; set; }

        [Required]
        [DefaultValue(60)]
        [DisplayName("Break duration, hours")]
        public float BreakDurationHours { get; set; }

        public string FullName => Name + " " + Surname;
    }
}