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
            var Apply = await GetAsync<IEnumerable<ApplyForWFHListViewModel>>(Helper.ApplyForWFHGetAll);
            ApplyForWFHListViewModel model = new ApplyForWFHListViewModel();
            model.ApplyForWFHs = Apply;
            return View(model);
        }
        [HttpGet] 
        public async Task<IActionResult> Create()
        {
            var DeptGetAll = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            var EmployeeGetAll = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
            ApplyForWFHCreateViewModel model = new ApplyForWFHCreateViewModel();
            model.Department = DeptGetAll.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            model.Employee = EmployeeGetAll.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FullName
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            try
            {
                var DeptGetAll = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var EmployeeGetAll = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
                var edit = await GetAsync<ApplyForWFHListViewModel>(String.Format(Helper.ApplyForWFHEdits, id));
                if (edit == null)
                {
                    return RedirectToAction("Index");
                }
                ApplyForWFHListViewModel model = new ApplyForWFHListViewModel();
                model = edit;
                model.Department = DeptGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model.Employee = EmployeeGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FullName
                }).ToList();
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
           
        
            //return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var delete = GetAsync<ApplyForWFHListViewModel>(String.Format(Helper.ApplyForWFHDeletes, id)).Result;
            var empid = delete.EmployeeId;
            var deptid = delete.DepartmentId;
            ApplyForWFHListViewModel model = new ApplyForWFHListViewModel();
            model = delete;
            var EmployeeName = GetAsync<EmployeeListViewModel>(String.Format(Helper.EmployeeDeletes, empid)).Result;
            var DepartmentName = GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentEdits, deptid)).Result;
            model.EmployeeName = EmployeeName.FullName;
            model.DepartmentName = DepartmentName.Name;
            return View(model);
        }

        [HttpPost] 
        public async Task<IActionResult> Create(ApplyForWFHCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var add = await PostAsync<ApplyForWFHCreateViewModel>(model, Helper.ApplyForWFHGetAll);
                    return RedirectToAction("Index");
                }
                var DeptGetAll = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var EmployeeGetAll = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
                ApplyForWFHCreateViewModel model1 = new ApplyForWFHCreateViewModel();
                model1.Department = DeptGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model1.Employee = EmployeeGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FullName
                }).ToList();
                model = model1;
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
         
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplyForWFHListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edit = await PutAsync<ApplyForWFHListViewModel>(Helper.ApplyForWFHEdits, model);
                    return RedirectToAction("Index");
                }
                var DeptGetAll = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var EmployeeGetAll = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
                ApplyForWFHListViewModel model1 = new ApplyForWFHListViewModel();
                model1.Department = DeptGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model1.Employee = EmployeeGetAll.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FullName
                }).ToList();
                model = model1;
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ApplyForWFH model)
        {
           var del = await DeleteAsync<ApplyForWFH>(string.Format(Helper.ApplyForWFHDeletes,model.Id));
            return RedirectToAction("Index");
        }
    }
}
