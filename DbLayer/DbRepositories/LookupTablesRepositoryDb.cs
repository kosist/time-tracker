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
        private readonly DbSet<DepartmentDb> _departmentEntities;
        private readonly DbSet<PositionDb> _positionEntities;
        private readonly DbSet<ActivityTypeDb> _activityTypeEntities;
        private readonly IMapper _mapper;

        public LookupTablesRepositoryDb(DbContext context, IMapper mapper)
        {
            Context = context;
            _departmentEntities = Context.Set<DepartmentDb>();
            _positionEntities = Context.Set<PositionDb>();
            _activityTypeEntities = Context.Set<ActivityTypeDb>();
            _mapper = mapper;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _departmentEntities.ToList().Select(_mapper.Map<DepartmentDb, Department>);
        }

        public IEnumerable<Position> GetPositions()
        {
            return _positionEntities.ToList().Select(_mapper.Map<PositionDb, Position>);
        }

        public IEnumerable<ActivityType> GetActivityTypes()
        {
            return _activityTypeEntities.ToList().Select(_mapper.Map<ActivityTypeDb, ActivityType>);
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
