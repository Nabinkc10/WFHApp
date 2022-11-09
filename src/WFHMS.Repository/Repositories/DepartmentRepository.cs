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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
           

            

        }

      
    }
}
