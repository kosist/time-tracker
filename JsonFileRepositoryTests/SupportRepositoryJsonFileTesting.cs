﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;

namespace JsonFileRepositoryTests
{
    class SupportRepositoryJsonFileTesting
    {
        public static User GenerateUserA(string department, string position)
        {
            var user = new User
            {
                Id = 0,
                Name = "John",
                Surname = "Malkovic",
                Department = new Department { Name = department },
                Position = new Position { Name = position },
                NumberOfWorkingDaysPerWeek = 5,
                NumberOfDailyWorkHours = 8,
                BreakDurationHours = 60
            };
            return user;
        }

        public static User GenerateUserB(string department, string position)
        {
            var user = new User
            {
                Id = 1,
                Name = "Will",
                Surname = "Smith",
                Department = new Department { Name = department },
                Position = new Position { Name = position },
                NumberOfWorkingDaysPerWeek = 5,
                NumberOfDailyWorkHours = 4,
                BreakDurationHours = 30
            };
            return user;
        }

        public static TimeRecord GenerateStartWorkingTimeRecord(int id, User user, int daysShiftFromToday)
        {
            var timeRecord = new TimeRecord
            {
                Id = id,
                User = user,
                RecordTime = DateTime.Today.AddDays(daysShiftFromToday),
                ActivityType = new ActivityType { Name = "Start Work" }
            };

            return timeRecord;
        }
        public static List<UserReport> GenerateUserWeeklyReportRecords(User user, DateTime startDay)
        {
            var userReports = new List<UserReport>();

            for (int i = 0; i < 7; i++)
            {
                var userReport = new UserReport
                {
                    User = user,
                    Date = startDay.AddDays(i)
                };
                userReports.Add(userReport);
            }
            return userReports;
        }
    }
}
