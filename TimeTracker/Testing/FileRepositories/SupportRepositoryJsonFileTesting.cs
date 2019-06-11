using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace TimeTracker.Testing.FileRepositories
{
    class SupportRepositoryJsonFileTesting
    {
        // generate users with some static parameters
        public static User GenerateUserA(string department, string position)
        {
            var user = new User
            {
                Name = "John",
                Surname = "Malkovic",
                Department = new Department{ Name = department },
                Position = new Position{ Name = position },
                NumberOfWorkingDaysPerWeek = 5,
                NumberOfDailyWorkHours = 8,
                BreakDurationInMinutes = 60
            };
            return user;
        }

        public static User GenerateUserB(string department, string position)
        {
            var user = new User
            {
                Name = "Will",
                Surname = "Smith",
                Department = new Department { Name = department },
                Position = new Position { Name = position },
                NumberOfWorkingDaysPerWeek = 5,
                NumberOfDailyWorkHours = 4,
                BreakDurationInMinutes = 30
            };
            return user;
        }

        public static TimeRecord GenerateStartWorkingTimeRecord(User user, int daysShiftFromToday)
        {
            var timeRecord = new TimeRecord
            {
                User = user,
                RecordTime = DateTime.Today.AddDays(daysShiftFromToday),
                TypeOfActivity = new TypeOfActivity {Name = "Start Work"}
            };

            return timeRecord;
        }
    }
}
