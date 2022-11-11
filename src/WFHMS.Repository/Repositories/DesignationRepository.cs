using Microsoft.EntityFrameworkCore;
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
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DesignationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public async Task<IEnumerable<Designation>> GetAllDesignation()
        {
           return await _applicationDbContext.Designations.Include(s => s.Departments).ToListAsync();

            
        }
    }
}
