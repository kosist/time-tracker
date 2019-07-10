﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.DataModels
{
    [Table("ActivityTypes")]
    public class ActivityTypeDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
