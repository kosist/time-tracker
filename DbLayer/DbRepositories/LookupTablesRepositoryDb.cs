using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer.DataModels;

namespace DbLayer.DbRepositories
{
    public class LookupTablesRepositoryDb : ILookupTablesRepository
    {
        private bool _disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<Department> _departmentEntities;
        private readonly DbSet<Position> _positionEntities;
        private readonly DbSet<ActivityType> _activityTypeEntities;
        private readonly IMapper _mapper;

        public LookupTablesRepositoryDb(DbContext context, IMapper mapper)
        {
            Context = context;
            _departmentEntities = Context.Set<Department>();
            _positionEntities = Context.Set<Position>();
            _activityTypeEntities = Context.Set<ActivityType>();
            _mapper = mapper;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _departmentEntities.ProjectTo<Department>().ToList();
        }

        public IEnumerable<Position> GetPositions()
        {
            return _positionEntities.ProjectTo<Position>().ToList();
        }

        public IEnumerable<ActivityType> GetActivityTypes()
        {
            return _activityTypeEntities.ProjectTo<ActivityType>().ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
