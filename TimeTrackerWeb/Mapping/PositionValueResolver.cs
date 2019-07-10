using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BaseLayer.DataModels;
using DbLayer.DbRepositories;

namespace TimeTrackerWeb.Mapping
{
    public class PositionValueResolver : IValueResolver<int, Position, Position>
    {
        private static IUnitOfWork _context;

        public PositionValueResolver(IUnitOfWork context)
        {
            _context = context;
        }
        public Position Resolve(int source, Position destination, Position destMember, ResolutionContext context)
        {
            return _context.LookupTables.GetPositions().Single(pos => pos.Id == source);
        }
    }
}