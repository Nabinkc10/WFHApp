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
        IEnumerable<DesignationListViewModel> GetAll();
        Task Add(DesignationCreateViewModel designation);
        Task Update(DesignationListViewModel designation);
    }
}
