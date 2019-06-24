﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.DataModels;

namespace DbLayer
{
    public class TimeTrackerDbContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }
        public DbSet<UserReportDb> UserReports { get; set; }
        public DbSet<TimeRecordDb> TimeRecords { get; set; }
    }
}