using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace WFHMS.Web.Controllers
{
    public class ApplyForWFHController : BaseController
    {
        private readonly ILogger<ApplyForWFHController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration configure;
        
        
        

        public ApplyForWFHController(ILogger<ApplyForWFHController> logger, HttpClient httpClient, IConfiguration configure) : base(configure, httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            this.configure = configure;
           
            
        }

        public async Task<IActionResult> Index()
        {
            //ViewBag.departmentList = GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);

//            GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll, "Id", "Name");

            var Apply = await GetAsync<IEnumerable<ApplyForWFHListViewModel>>(Helper.ApplyForWFHGetAll);
            ApplyForWFHListViewModel model = new ApplyForWFHListViewModel();
            model.ApplyForWFHs = Apply;
            return View(model);
        }
        [HttpGet] 
        public async Task<IActionResult> Create()
        {
            var Apply = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            var Employee = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
            ApplyForWFHCreateViewModel model = new ApplyForWFHCreateViewModel();
            model.Department = Apply.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            model.Employee = Employee.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FullName
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var Apply = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            var Employee = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
            ApplyForWFHListViewModel model = new ApplyForWFHListViewModel();
            model.Department = Apply.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            model.Employee = Employee.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FullName
            }).ToList();
            return View(model);
            //return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Create(ApplyForWFHCreateViewModel model)
        {
           
            var add = await PostAsync<ApplyForWFHCreateViewModel>(model, Helper.ApplyForWFHGetAll);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplyForWFHListViewModel model)
        {
            var edit = await PutAsync<ApplyForWFHListViewModel>(Helper.ApplyForWFHEdits, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ApplyForWFH model)
        {
           var del = await DeleteAsync<ApplyForWFH>(string.Format(Helper.ApplyForWFHDeletes,model.Id));
            return RedirectToAction("Index");
        }
    }
}
