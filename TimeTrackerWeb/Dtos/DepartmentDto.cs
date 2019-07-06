using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTrackerWeb.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}