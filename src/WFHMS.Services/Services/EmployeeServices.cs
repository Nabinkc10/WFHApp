using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Repository.Infrastructure;
using WFHMS.Models.ViewModel;
using WFHMS.Data.Entities;

namespace WFHMS.Services.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Employee>GetAsync(int id)
        {
            return await unitOfWork.Employee.GetAsync(id);
        }
        public IEnumerable<EmployeeListViewModel>GetAll()
        {
            var emp = unitOfWork.Employee.GetAllWFH();
            var retn = emp.Select(p => new EmployeeListViewModel()
            {
                Id = p.Id,
                FullName = p.FullName,
                EmployeeCode = p.EmployeeCode,
                Gender = p.Gender,
                PicturePath = p.PicturePath,
                Address = p.Address,
                DOB = p.DOB,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                DesignationName = p.Designation.DesignationName,
                DepartmentName = p.Departments.Name
            });
            return retn;

        }
        public async Task Add(EmployeeCreateViewModel employee)
        {
            var employ = mapper.Map<EmployeeCreateViewModel, Employee>(employee);
            await unitOfWork.Employee.Add(employ);
            await unitOfWork.CompleteAsync();
        }
        public async Task Update(EmployeeListViewModel employee)
        {
            var edit = mapper.Map<EmployeeListViewModel, Employee>(employee);
            await unitOfWork.Employee.Update(edit);
            await unitOfWork.CompleteAsync();
        }

        public async Task Delete(Employee employee)
        {
            var delt = mapper.Map<Employee>(employee);
            unitOfWork.Employee.Delete(delt);
            await unitOfWork.CompleteAsync();
        }
    }
}
