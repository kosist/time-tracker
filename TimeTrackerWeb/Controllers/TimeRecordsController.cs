﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DbRepositories;
using TimeTrackerWeb.Dtos;
using TimeTrackerWeb.ViewModels;

namespace TimeTrackerWeb.Controllers
{
    public class TimeRecordsController : Controller
    {
        private IUnitOfWork _context;
        private readonly IMapper _mapper;

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
            _context.TimeRecords.InsertTimeRecord(record);
            _context.Complete();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult AssignActivity(int id)
        {
            var lastUserActivityId = _context.TimeRecords.GetLastUserRecord(id).ActivityType.Id;
            IEnumerable<ActivityType> activities;

            if (lastUserActivityId == 1) // break
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Id != 1);
            }
            else if (lastUserActivityId == 2) // start work
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Id != 2);
            }
            else if (lastUserActivityId == 3) // stop work
            {
                activities = _context.LookupTables.GetActivityTypes().Where(act => act.Id != 1 && act.Id != 3);
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