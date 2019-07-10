using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTrackerWeb.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}