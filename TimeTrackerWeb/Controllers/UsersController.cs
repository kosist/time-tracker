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
            var users = _context.Users.GetUsers().Select(_mapper.Map<User, UserDto>);
            return View(users);
        }

        public ActionResult New()
        {
            var positionsList = _context.LookupTables.GetPositions();
            var departmentsList = _context.LookupTables.GetDepartments();
            var model = new UserFormViewModel
            {
                User = new UserDto(),
                Departments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentsList),
                Positions = _mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(positionsList)
            };
            return View("UserForm", model);
        }

        public ActionResult Save(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                var positionsList = _context.LookupTables.GetPositions();
                var departmentsList = _context.LookupTables.GetDepartments();
                var viewModel = new UserFormViewModel
                {
                    User = user,
                    Departments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentsList),
                    Positions = _mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(positionsList)
                };
                return View("UserForm", viewModel);
            }

            if (user.Id == 0)
            {
                var userNew = _mapper.Map<UserDto, User>(user);
                userNew.Department = _context.LookupTables.GetDepartments().Single(dep => dep.Id == user.Department.Id);
                userNew.Position = _context.LookupTables.GetPositions().Single(dep => dep.Id == user.Position.Id);
                _context.Users.InsertUser(userNew);
            }
            else
            {
                var userInDb = _context.Users.GetUserById(user.Id);
                userInDb.Name = user.Name;
                userInDb.Surname = user.Surname;
                userInDb.Department = _mapper.Map<DepartmentDto, Department>(user.Department);
                userInDb.Position = _mapper.Map<PositionDto, Position>(user.Position);
                userInDb.NumberOfDailyWorkHours = user.NumberOfDailyWorkHours;
                userInDb.NumberOfWorkingDaysPerWeek = user.NumberOfWorkingDaysPerWeek;
                userInDb.BreakDurationHours = user.BreakDurationHours;
                _context.Users.UpdateUser(userInDb);
            }
            _context.Complete();
            return RedirectToAction("Index", "Users");
        }

        public ActionResult Edit(int id)
        {
            var userToEdit = _context.Users.GetUserById(id);
            var user = _mapper.Map<User, UserDto>(userToEdit);
            if (userToEdit == null)
                return HttpNotFound();

            var positionsList = _context.LookupTables.GetPositions();
            var departmentsList = _context.LookupTables.GetDepartments();
            var viewModel = new UserFormViewModel
            {
                User = user,
                Departments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentsList),
                Positions = _mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(positionsList)
            };
            return View("UserForm", viewModel);

        }
    }
}