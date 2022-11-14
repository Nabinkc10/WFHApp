using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.Services.Services
{
    public interface IApplyForWFHServices
    {
        Task<ApplyForWFH> GetAsync(int id);
        IEnumerable<ApplyForWFHListViewModel> GetAll();

        Task Add(ApplyForWFHCreateViewModel applyForWFH);

        Task Update(ApplyForWFHListViewModel applyForWFH);

        Task Delete(ApplyForWFH model);
    }
}
