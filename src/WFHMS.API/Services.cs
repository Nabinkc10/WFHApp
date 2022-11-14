
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.API
{
    public class Services
    {
       
            public static void RegisterServices(IServiceCollection services)
            {
                #region services
                services.AddTransient<IDepartmentServices, DepartmentServices>();
                services.AddTransient<IDesignationServices, DesignationServices>();
                services.AddTransient<IEmployeeService, EmployeeServices>();
                services.AddTransient<IApplyForWFHServices, ApplyForWFHServices>(); 


            #endregion

            #region repository
            services.AddTransient<IUnitOfWork, UnitOfWork>();
                #endregion
            }

    }
}
