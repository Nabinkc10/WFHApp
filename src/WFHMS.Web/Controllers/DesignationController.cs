using Microsoft.AspNetCore.Mvc;
using WFHMS.Models.ViewModel;

namespace WFHMS.Web.Controllers
{
    public class DesignationController : BaseController
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly HttpClient _httpClient;
        public readonly IConfiguration configure;
        public DesignationController(ILogger<DesignationController> logger, IConfiguration configure, HttpClient httpClient)
            : base(configure, httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            this.configure = configure;
        }


        public async Task<IActionResult> Index()
        {
            var designdis = await GetAsync<IEnumerable<DesignationListViewModel>>(Helper.DesignationGetAll);
            DesignationListViewModel model = new DesignationListViewModel();
            model.Designation= designdis;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DesignationCreateViewModel model)
        {

            var add = await PostAsync<DesignationCreateViewModel>(model, Helper.DesignationEndPoint);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(DesignationListViewModel model)
        {
            var edit = await PutAsync<DesignationListViewModel>(Helper.DesignationEdits, model);
            return RedirectToAction("Index");
        }
    }
}
