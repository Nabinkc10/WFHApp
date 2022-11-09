 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Repository.Repositories;

namespace WFHMS.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IEmployeeRepository _employeeRepository;
        private  IRepository<Department> _departmentRepository;
        private IRepository<Designation> _designationRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_dbContext);
        public IRepository<Department> Department => _departmentRepository ??= new Repository<Department>(_dbContext);
        public IRepository<Designation> Designation => _designationRepository ??= new Repository<Designation>(_dbContext);
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
