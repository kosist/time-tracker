using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("ActivityTypes")]
    class ActivityTypeDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
