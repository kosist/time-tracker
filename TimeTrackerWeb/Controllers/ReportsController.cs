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
    public class ReportsController : Controller
    {
        private IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ReportsController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var users = _context.Users.GetUsers();

            var view = new UserReportSelectorViewModel
            {
                Users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users),
                User = new UserDto()
            };

            return View(view);
        }

        //public ActionResult GetReports(int userId, DateTime startDate, DateTime endDate)
        public ActionResult GetReports(UserReportSelectorViewModel userReportSelector)
        {
            var user = _context.Users.GetUserById(userReportSelector.User.Id);
            var userDto = _mapper.Map<User, UserDto>(user);
            var records = _context.UserReports.GetReportsByTimeRange(user, userReportSelector.StartDate, userReportSelector.EndDate).Select(_mapper.Map<UserReport, UserReportDto>);

            var reportsViewModel = new ReportsViewModel
            {
                User = userDto,
                Reports = records
            };
            return View("UsersReports", reportsViewModel);
        }

    }
}