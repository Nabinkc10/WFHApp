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
            //ApplyForWFHListViewModel applyForWFHCreateViewModel = new ApplyForWFHListViewModel();
            //List<SelectListItem> departments = _unitOfWork.Department.Query().OrderBy(p => p.Id).Select(p => new SelectListItem
            //{
            //    Selected = true,
            //    Value = p.Id.ToString(),
            //    Text = p.Name
            //}).ToList();
            //applyForWFHCreateViewModel.Department = departments;
            //List<SelectListItem> employees = _unitOfWork.Employee.Query().OrderBy(p => p.Id).Select(p => new SelectListItem
            //{
            //    Selected = true,
            //    Value = p.Id.ToString(),
            //    Text = p.FullName
            //}).ToList();
            //applyForWFHCreateViewModel.Employee = employees;


            var retn = apply.Select(p => new ApplyForWFHListViewModel()
            {
                Id = p.Id,
                FullName = p.FullName,
                From = p.From,
                To = p.To,
                LeaveType = p.LeaveType,
                EmployeeId= p.EmployeeId,
                DepartmentId = p.DepartmentId,
               
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
