using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.Web
{
    public class Services
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region
            services.AddTransient<HttpClient, HttpClient>();
           


            #endregion
          
        }
    }
}
