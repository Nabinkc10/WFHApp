using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Repository.Repositories;

namespace WFHMS.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        IRepository<Department> Department { get; }
        IRepository<ApplyForWFH> ApplyForWFH { get; }
        IDesignationRepository Designation { get; }
        public Task<int> CompleteAsync();
    }
}
