using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("Users")]
    public class UserDb
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public DepartmentDb Department { get; set; }

        public int DepartmentId { get; set; }

        public PositionDb Position { get; set; }

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
