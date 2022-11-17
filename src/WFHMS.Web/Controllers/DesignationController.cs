using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WFHMS.Data.Entities;
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
            DesignationListViewModel model = new();
            model.Designation = designdis;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            DesignationCreateViewModel model = new DesignationCreateViewModel();
            model.Department = Desgn.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            var edit = await GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationEdits, id));
            DesignationListViewModel model = new DesignationListViewModel();
            model = edit;
            model.Department = Desgn.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            }).ToList();
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var getdegbyId = GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationDeletes, id)).Result;
            return View(getdegbyId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesignationCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var add = await PostAsync<DesignationCreateViewModel>(model, Helper.DesignationGetAll);
                return RedirectToAction("Index");
            }
            return View(model);
          
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DesignationCreateViewModel model)
        {
            var edit = await PutAsync<DesignationCreateViewModel>(Helper.DesignationEdits, model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Designation model)
        {
            var del = await DeleteAsync<Designation>(string.Format(Helper.DesignationDeletes, model.Id));

            return RedirectToAction("Index");
        }
    }
}
