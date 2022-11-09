using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
