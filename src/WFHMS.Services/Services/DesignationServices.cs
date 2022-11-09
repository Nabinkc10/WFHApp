using AutoMapper;
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
    public class DesignationServices : IDesignationServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DesignationServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Designation>GetAsync(int id)
        {
            return await unitOfWork.Designation.GetAsync(id);
        }
        public IEnumerable<DesignationListViewModel>GetAll()
        {
            var deg = unitOfWork.Designation.GetAll();
            var ret = deg.Select(p => new DesignationListViewModel()
            {
                DesignationName = p.DesignationName,
                Id = p.Id,
                DepartmentId = p.DepartmentId,
               

            });
            return ret;
        }
        public async Task Add(DesignationCreateViewModel designation)
        {
            var data = mapper.Map<DesignationCreateViewModel, Designation>(designation);
            await unitOfWork.Designation.Add(data);
            await unitOfWork.CompleteAsync();

        }
        public async Task Update(DesignationListViewModel designation)
        {
         var edit = mapper.Map<DesignationListViewModel,Designation>(designation);
         await unitOfWork.Designation.Update(edit);
         await unitOfWork.CompleteAsync();
        }

    }
}