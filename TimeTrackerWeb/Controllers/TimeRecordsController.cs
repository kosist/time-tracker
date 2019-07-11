using System;
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

        public ActionResult SaveRecord()
        {
            throw new NotImplementedException();
        }
    }
}