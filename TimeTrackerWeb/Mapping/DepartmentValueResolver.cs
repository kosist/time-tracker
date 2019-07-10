using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DbRepositories;

namespace TimeTrackerWeb.Mapping
{
    public class DepartmentValueResolver : IValueResolver<int, Department, Department>
    {
        private static IUnitOfWork _context;

        public DepartmentValueResolver(IUnitOfWork context)
        {
            _context = context;
        }

        public Department Resolve(int source, Department destination, Department destMember, ResolutionContext context)
        {
            return _context.LookupTables.GetDepartments().Single(dep => dep.Id == source);
        }
    }
}