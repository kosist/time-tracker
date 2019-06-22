using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("Departments")]
    class DepartmentDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
