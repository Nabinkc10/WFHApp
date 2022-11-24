using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Department> GetAsync(int id)
        {
            return await unitOfWork.Department.GetAsync(id);
        }


        public async Task<IEnumerable<DepartmentListViewModel>> GetAll()
        {
            var dept =await unitOfWork.Department.GetAll();
            
            var retn = dept.Select(p => new DepartmentListViewModel()
            {
                Name = p.Name,
                Id = p.Id,
                //DepartmentId =p.DepartmentId
            });
           
            return retn;

        }
        public async Task<Department> CheckDuplicateAdd(DepartmentCreateViewModel department)
        {
            var dupdepadd = await unitOfWork.Department.FindAsync(m => m.Name == department.Name);
            return dupdepadd;
        }
       
        public async Task Add(DepartmentCreateViewModel department)
        {
            var data = mapper.Map<DepartmentCreateViewModel, Department>(department);
            await unitOfWork.Department.Add(data);
            await unitOfWork.CompleteAsync();



        }
        public async Task<Department> CheckDuplicateUpdate(DepartmentListViewModel department)
        {
            var dupdupedit = await unitOfWork.Department.FindAsync(m => m.Name == department.Name);
            return dupdupedit;
        }

        public async Task Update(DepartmentListViewModel department)
        {
            var edit = mapper.Map<DepartmentListViewModel, Department>(department);
           await unitOfWork.Department.Update(edit);
           await unitOfWork.CompleteAsync();
        }

        public async Task Delete(Department department)
        {
            var del = mapper.Map<Department>(department);
            unitOfWork.Department.Delete(del);
            await unitOfWork.CompleteAsync();
        }
    }
}
