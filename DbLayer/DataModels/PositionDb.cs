using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("Positions")]
    public class PositionDb
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
