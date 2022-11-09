using AutoMapper;
using WFHMS.Data.Entities;

namespace WFHMS.Models.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentListViewModel>().ReverseMap();
            CreateMap<Designation, DesignationListViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListViewModel>().ReverseMap();
        }
    }
    
}