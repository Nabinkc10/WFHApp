using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using WFHMS.Data.Entities;
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
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var EmployGet = await GetAsync<IEnumerable<EmployeeListViewModel>>(Helper.EmployeeGetAll);
            EmployeeListViewModel model = new EmployeeListViewModel();
            model.Employee = EmployGet;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            var DeptGet = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            var DegGet = await GetAsync<IEnumerable<DesignationListViewModel>>(Helper.DesignationGetAll);
            EmployeeCreateViewModel model = new EmployeeCreateViewModel();
            model.Department = DeptGet.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            model.Designation = DegGet.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.DesignationName
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var DeptGet = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var DegGet = await GetAsync<IEnumerable<DesignationListViewModel>>(Helper.DesignationGetAll);
                var edit = await GetAsync<EmployeeListViewModel>(String.Format(Helper.EmployeeEdits, id));
                if(edit == null)
                {
                    return RedirectToAction("Index");
                }
                EmployeeListViewModel model = new EmployeeListViewModel();
                model = edit;
                model.Department = DeptGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model.Designation = DegGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.DesignationName
                }).ToList();
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
          
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var getempbyId = GetAsync<EmployeeListViewModel>(String.Format(Helper.EmployeeDeletes, id)).Result;
            var deptId = getempbyId.DepartmentId;
            var designationId = getempbyId.DesignationId;
            var deptName = GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentDeletes, deptId)).Result;
            var designationName = GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationDeletes, designationId)).Result;
            EmployeeListViewModel model = new EmployeeListViewModel();
            model = getempbyId;
            model.DepartmentName = deptName.Name;
            model.DesignationName = designationName.DesignationName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Create(EmployeeCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var add = await PostAsync<EmployeeCreateViewModel>(model, Helper.EmployeeGetAll);
                    return RedirectToAction("Index");
                }
                var DeptGet = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var DegGet = await GetAsync<IEnumerable<DesignationListViewModel>>(Helper.DesignationGetAll);
                EmployeeCreateViewModel model1 = new EmployeeCreateViewModel();
                model1.Department = DeptGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model1.Designation = DegGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.DesignationName
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
        public async Task<IActionResult> Edit(EmployeeListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edit = await PutAsync<EmployeeListViewModel>(Helper.EmployeeEdits, model);
                    return RedirectToAction("Index");
                }
                var DeptGet = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var DegGet = await GetAsync<IEnumerable<DesignationListViewModel>>(Helper.DesignationGetAll);
                EmployeeListViewModel model1 = new EmployeeListViewModel();
                model1.Department = DeptGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                model1.Designation = DegGet.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.DesignationName
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
        public async Task<IActionResult> DeleteConfirmed(Employee model)
        {
            var del = await DeleteAsync<Employee>(string.Format(Helper.EmployeeDeletes, model.Id));
            return RedirectToAction("Index");
        }


    }
}
