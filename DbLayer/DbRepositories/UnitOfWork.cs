using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.IRepositories;

namespace DbLayer.DbRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IUserRepository Users{ get; private set; }
        public ITimeRecordRepository TimeRecords { get; private set; }
        public IUserReportRepository UserReports { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Users = new UserRepositoryDb(context);
            TimeRecords = new TimeRecordRepositoryDb(context);
            UserReports = new UserReportRepositoryDb(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
