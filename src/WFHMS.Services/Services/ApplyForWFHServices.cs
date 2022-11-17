using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Services.Services
{
    public class ApplyForWFHServices : IApplyForWFHServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        
        public ApplyForWFHServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
          
        }
        public async Task<ApplyForWFH>GetAsync(int id)
        {
            return await _unitOfWork.ApplyForWFH.GetAsync(id);
        }
        public IEnumerable<ApplyForWFHListViewModel> GetAll()
        {
            var apply = _unitOfWork.ApplyForWFH.GetAllWFH();
            var retn = apply.Select(p => new ApplyForWFHListViewModel()
            {
                Id = p.Id,
                FullName = p.FullName,
                From = p.From,
                To = p.To,
                LeaveType = p.LeaveType,
                EmployeeId= p.EmployeeId,
                DepartmentName = p.Departments.Name,
                EmployeeName = p.Employee.FullName,
                Reason = p.Reason,
            });
            return retn;
        }
        
        public async Task Add(ApplyForWFHCreateViewModel applyForWFH)
        {
            var data = mapper.Map<ApplyForWFHCreateViewModel, ApplyForWFH>(applyForWFH);
            await _unitOfWork.ApplyForWFH.Add(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(ApplyForWFHListViewModel applyForWFH)
        {
          var edit = mapper.Map<ApplyForWFHListViewModel, ApplyForWFH>(applyForWFH);
            await _unitOfWork.ApplyForWFH.Update(edit);
            await _unitOfWork.CompleteAsync();
          
        }
        
        public async Task Delete(ApplyForWFH applyForWFH)
        {
            var delt = mapper.Map<ApplyForWFH>(applyForWFH);
            _unitOfWork.ApplyForWFH.Delete(delt);
            await _unitOfWork.CompleteAsync();
        }
    }
}
