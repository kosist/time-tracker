using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TimeTrackerWeb.Dtos;

namespace TimeTrackerWeb.ViewModels
{
    public class TimeRecordViewModel
    {
        [DisplayName("User")]
        public IEnumerable<UserDto> Users { get; set; }
        [DisplayName("Activity Type")]
        public IEnumerable<ActivityTypeDto> ActivityTypes { get; set; }

        public UserDto User { get; set; }
        public ActivityTypeDto Activity { get; set; }

    }
}