using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly HttpClient _httpClient;
        public readonly IConfiguration configure;
        

        

        public DepartmentController(ILogger<DepartmentController> logger, IConfiguration configure, HttpClient httpClient)
            : base(configure, httpClient)
        {
            _logger = logger;
            this.configure = configure;
            _httpClient = httpClient;
            
            
             
        }
        public async Task<IActionResult> Index()
        {

            var deptdis = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            DepartmentListViewModel model = new DepartmentListViewModel();
            model.Department = deptdis;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(DepartmentCreateViewModel model)
        {

            var add = await PostAsync<DepartmentCreateViewModel>(model,Helper.DepartmentEndPoint);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentListViewModel model)
        {
            var edit = await PutAsync<DepartmentListViewModel>(Helper.DepartmentEdits , model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentListViewModel model)
        {
           var del = await DeleteAsync<DepartmentListViewModel>(Helper.DepartmentDelete);
       
            return RedirectToAction("Index");
        }

    }

}
