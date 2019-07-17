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

            var view = new UsersListViewModel
            {
                Users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users),
            };

            return View(view);
        }
    }
}