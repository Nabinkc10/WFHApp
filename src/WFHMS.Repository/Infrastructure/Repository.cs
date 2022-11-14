
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Repository.Infrastructure
{
    public class Repository<entity> : IRepository<entity> where entity : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(entity entity)
        {
            await _dbContext.Set<entity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<entity> entities)
        {
           await _dbContext.Set<entity>().AddRangeAsync(entities);
        }

        public void Delete(entity entity)
        {
             _dbContext.Set<entity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<entity> entities)
        {
            _dbContext.Set<entity>().RemoveRange(entities);
        }

        public async Task<entity> FindAsync(Expression<Func<entity, bool>> predicate)
        {
            return await _dbContext.Set<entity>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<entity> Query()
        {
            return _dbContext.Set<entity>().AsQueryable();
        }
        public async Task<IEnumerable<entity>> GetAll()
        {
            return await _dbContext.Set<entity>().ToListAsync();
        }


        public async Task<entity> GetAsync(int id)
        {
            return await _dbContext.Set<entity>().FindAsync(id);
        }

      

        public async Task Update(entity entity)
        {
           _dbContext.Set<entity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<entity> entities)
        {
            _dbContext.Set<entity>().UpdateRange(entities);
        }

        public IQueryable<entity> GetAllWFH()
        {
            return _dbContext.Set<entity>();
        }
    }
}
