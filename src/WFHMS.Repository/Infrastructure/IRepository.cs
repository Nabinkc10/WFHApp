using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Repository.Infrastructure
{
    public interface IRepository<entity> where entity : class
    {
        Task<IEnumerable<entity>> GetAll();
        Task<entity> GetAsync(int id);
        Task<entity> FindAsync(Expression<Func<entity, bool>> predicate);
        IQueryable<entity> Query();
        Task Add(entity entity);
        Task AddRange(IEnumerable<entity> entities);
        Task Update(entity entity);
        void UpdateRange(IEnumerable<entity> entities);

        void Delete(entity entity);
        void DeleteRange(IEnumerable<entity> entities);
    }
}
