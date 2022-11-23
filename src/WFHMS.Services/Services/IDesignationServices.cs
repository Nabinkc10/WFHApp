using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.Services.Services
{
    public interface IDesignationServices
    {
        Task<Designation> GetAsync(int id);
        Task<IEnumerable<DesignationListViewModel>> GetAll();
        Task<Designation> CheckDuplicateAdd(DesignationCreateViewModel designation);
        Task Add(DesignationCreateViewModel designation);
        Task<Designation> CheckDuplicateUpdate(DesignationListViewModel designation);
        Task Update(DesignationListViewModel designation);
        Task Delete(Designation model);
    }
}
