using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("Departments")]
    public class DepartmentDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
