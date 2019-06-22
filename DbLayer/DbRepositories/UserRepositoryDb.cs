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
        private bool disposed = false;
        protected readonly DbContext Context;
        private readonly DbSet<UserDb> Entities;
        public UserRepositoryDb(DbContext context)
        {
            Context = context;
            Entities = Context.Set<UserDb>();
        }

        #region Interface Implementation

        public User GetUserById(int userId)
        {
            var userDb = Entities.Find(userId);
            return Mapper.Map<UserDb, User>(userDb)
        }

        public IEnumerable<User> GetUsers()
        {
            return Entities.ToList().Select(Mapper.Map<UserDb, User>);
        }

        public void InsertUser(User user)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            Entities.Add(userDb);
        }

        public void UpdateUser(User user)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            Context.Entry(userDb).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            var userDb = Mapper.Map<User, UserDb>(user);
            Entities.Remove(userDb);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
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
            var departmentDb = Mapper.Map<Department, DepartmentDb>(department);
            return Entities.Include(u => u.Department).Where(u => u.Department.Id == departmentDb.Id).ToList().Select(Mapper.Map<UserDb, User>);
        } 
        #endregion


    }
}
