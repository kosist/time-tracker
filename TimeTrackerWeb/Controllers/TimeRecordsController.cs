using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BaseLayer.DataModels;
using Common.Tables;
using DbLayer.DbRepositories;
using TimeTrackerWeb.Dtos;
using TimeTrackerWeb.ViewModels;

namespace TimeTrackerWeb.Controllers
{
    public class TimeRecordsController : Controller
    {
        private IUnitOfWork _context;
        private readonly IMapper _mapper;
        protected readonly string BreakAlias = Activities.Break.ToString();
        protected readonly string StartWorkAlias = Activities.StartWork.ToString();
        protected readonly string StopWorkAlias = Activities.StopWork.ToString();

        public TimeRecordsController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewRecord()
        {
            var users = _context.Users.GetUsers();
            var activities = _context.LookupTables.GetActivityTypes();

            var view = new TimeRecordViewModel
            {
                Users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users),
                ActivityTypes = _mapper.Map<IEnumerable<ActivityType>, IEnumerable<ActivityTypeDto>>(activities),
            };

            return View(view);
        }

        public ActionResult SaveRecord(UserDto user, ActivityTypeDto activity)
        {
            var userInDb = _context.Users.GetUserById(user.Id);
            var activityInDb = _context.LookupTables.GetActivityTypes().SingleOrDefault(act => act.Id == activity.Id);

            if (userInDb == null)
                return HttpNotFound();
            if (activityInDb == null)
                return HttpNotFound();

            var record = new TimeRecord
            {
                RecordTime = DateTime.Now,
                User = userInDb,
                ActivityType = activityInDb,
            };
            

            /*
            Check, if user has record in UserReport table;
            get last record in TimeRecords table;
            check type of last activity;
            get current activity;
            for transitions:
                start work -> break;
                start work -> stop work: update working time
            for transitions:
                break -> start work;
                break -> stop work: update break time
            for transitions:
                nothing -> start work;
                stop work -> start work: update nothing
            For transitions to stop work, all the time update TimeDifference column                
             */

            var lastUserReport = _context.UserReports.GetDailyReport(userInDb);

            if (lastUserReport == null)
            {
                lastUserReport = new UserReport
                {
                    User = userInDb,
                    Date = DateTime.Today,
                    WorkHours = 8,
                    BreakHours = userInDb.BreakDurationInMinutes / 60,
                };
            }

            var lastActivityTypeName = "";
            var lastTimeRecord = _context.TimeRecords.GetLastUserRecord(userInDb.Id);
            if (lastTimeRecord == null)
            {
                lastActivityTypeName = lastTimeRecord.ActivityType.Name;
            }

            var currentActivityTypeName = activityInDb.Name;

            if ((lastActivityTypeName == StartWorkAlias))
            {
                if ((currentActivityTypeName == StopWorkAlias) | (currentActivityTypeName == BreakAlias))
                {
                    lastUserReport.WorkHours = DateTime.Now.Subtract(lastTimeRecord.RecordTime).TotalHours;
                }
            }

            _context.TimeRecords.InsertTimeRecord(record);
            _context.UserReports.UpdateUserReport(lastUserReport);
            _context.Complete();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult AssignActivity(int id)
        {
            var activityTypeName = _context.TimeRecords.GetLastUserRecord(id).ActivityType.Name;
            IEnumerable<ActivityType> activities;

            if (activityTypeName == BreakAlias)
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Name != BreakAlias);
            }
            else if (activityTypeName == StartWorkAlias)
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Name != StartWorkAlias);
            }
            else if (activityTypeName == StopWorkAlias)
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Name == StartWorkAlias);
            }
            else
                activities = _context.LookupTables.GetActivityTypes();

            var viewData = new TimeRecordViewModel
            {
                ActivityTypes = _mapper.Map<IEnumerable<ActivityType>, IEnumerable<ActivityTypeDto>>(activities),
            };

            return PartialView("ActivityList", viewData);
        }
    }
}