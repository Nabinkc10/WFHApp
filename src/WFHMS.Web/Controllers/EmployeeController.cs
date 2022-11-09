using Microsoft.AspNetCore.Mvc;
using WFHMS.Models.ViewModel;

namespace WFHMS.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly HttpClient _httpClient;
        public readonly IConfiguration configure;


        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configure, HttpClient httpClient)
            : base(configure, httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            this.configure = configure;
        }
        public async Task<IActionResult> Index()
        {
            var employdis = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
            EmployeeListViewModel model = new EmployeeListViewModel();
            model.Employee = employdis;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(EmployeeCreateViewModel model)
        {
            var add = await PostAsync<EmployeeCreateViewModel>(model, Helper.EmployeeEndPoint);
            return RedirectToAction("Index");
        }

    }
}
