using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.Services.Services
{
    public interface IEmployeeService
    {

        //Task <IEnumerable<EmployeeListViewModel>>GetAll();
        IEnumerable<EmployeeListViewModel> GetAll();
        Task<Employee> GetAsync(int id);
        Task Add(EmployeeCreateViewModel model);
        Task Update(EmployeeListViewModel employee);
        Task Delete(Employee model);
    }
}
