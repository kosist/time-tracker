using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.DbEntities
{
    [Table("ActivityTypes")]
    class ActivityTypeDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
