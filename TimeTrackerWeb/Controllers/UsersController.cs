using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DbRepositories;
using TimeTrackerWeb.Dtos;
using TimeTrackerWeb.Mapping;

namespace TimeTrackerWeb.Controllers
{
    public class UsersController : Controller
    {
        private IUnitOfWork _context;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var user = _context.Users.GetUserById(2);
            return View(_mapper.Map<User, UserDto>(user));
        }

        public ActionResult New()
        {
            return View();
        }
    }
}