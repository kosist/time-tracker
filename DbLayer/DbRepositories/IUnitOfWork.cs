using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.IRepositories;

namespace DbLayer.DbRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITimeRecordRepository TimeRecords { get; }
        IUserReportRepository UserReports { get; }
        int Complete();
    }
}
