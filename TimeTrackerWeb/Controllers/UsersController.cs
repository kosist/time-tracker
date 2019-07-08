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
using TimeTrackerWeb.ViewModels;

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
            return View();
        }

        public ActionResult New()
        {
            var positionsList = _context.LookupTables.GetPositions();
            var departmentsList = _context.LookupTables.GetDepartments();
            var model = new UserFormViewModel
            {
                User = new UserDto(),
                Departments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentsList),
                Positions = _mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(positionsList),
            };
            return View("UserForm", model);
        }

        public ActionResult Save()
        {
            throw new NotImplementedException();
        }
    }
}