using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.Services.Services
{
    public interface IDepartmentServices
    {
        Task Add(DepartmentCreateViewModel department);
        Task Update(DepartmentListViewModel department);
        Task Delete(Department model);
        Task<Department> GetAsync(int id);
        Task<IEnumerable<DepartmentListViewModel>>GetAll();
        
    }
}
