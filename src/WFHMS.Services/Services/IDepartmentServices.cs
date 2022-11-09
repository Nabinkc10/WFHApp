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
        Task Delete(DepartmentListViewModel departmentz);
        Task<Department> GetAsync(int id);
        IEnumerable<DepartmentListViewModel> GetAll();
        
    }
}
