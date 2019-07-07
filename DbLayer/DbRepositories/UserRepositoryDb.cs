using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseLayer.DataModels;
using BaseLayer.IRepositories;
using DbLayer.DataModels;

namespace DbLayer.DbRepositories
{
    public class UserRepositoryDb : IUserRepository
    {
        private bool _disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<UserDb> _entities;
        private readonly IMapper _mapper;
        public UserRepositoryDb(DbContext context, IMapper mapper)
        {
            Context = context;
            _entities = Context.Set<UserDb>();
            _mapper = mapper;
        }

        #region Interface implementation

        public User GetUserById(int userId)
        {
            var userDb = _entities.Find(userId);
            return _mapper.Map<UserDb, User>(userDb);
        }

        public IEnumerable<User> GetUsers()
        {
            return _entities.ToList().Select(_mapper.Map<UserDb, User>);
        }

        public void InsertUser(User user)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            _entities.Add(userDb);
        }

        public void UpdateUser(User user)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            Context.Entry(userDb).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            var userDb = _mapper.Map<User, UserDb>(user);
            _entities.Remove(userDb);
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

        #endregion

        #region Specific methods
        public IEnumerable<User> GetUsersOfDepartment(Department department)
        {
            var departmentDb = _mapper.Map<Department, DepartmentDb>(department);
            return _entities.Include(u => u.Department).Where(u => u.Department.Id == departmentDb.Id).ToList().Select(_mapper.Map<UserDb, User>);
        } 
        #endregion


    }
}
