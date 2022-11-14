using AutoMapper;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentListViewModel>().ReverseMap();
            CreateMap<Department, DepartmentCreateViewModel>().ReverseMap();
            CreateMap<Designation, DesignationListViewModel>().ReverseMap();
            CreateMap<Designation, DesignationCreateViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeCreateViewModel>().ReverseMap();
            CreateMap<ApplyForWFH, ApplyForWFHListViewModel>().ReverseMap();
            CreateMap<ApplyForWFH, ApplyForWFHCreateViewModel>().ReverseMap();
        }
    }
    
}