using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("Positions")]
    class PositionDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
