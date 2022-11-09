using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WFHMS.Web.Models;
using WFHMS.Web.Models.Message;

namespace WFHMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;    


        public HomeController(ILogger<HomeController> logger, IConfiguration configure, HttpClient httpClient)
            : base(configure, httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {

        
            return View();
        }

   
        public IActionResult Privacy()
        {
            return View();
           
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}