using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
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
            try
            {
                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var edit = await GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationEdits, id));
                if(edit == null)
                {
                    return RedirectToAction("Index");
                }
                DesignationListViewModel model = new DesignationListViewModel();
                model = edit;
                model.Department = Desgn.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                }).ToList();
                return View(model);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "unable to find the Id");
                return View("Edit");
            }
            
            //var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            //var edit = await GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationEdits, id));
            //DesignationListViewModel model = new DesignationListViewModel();
            //model = edit;
            //model.Department = Desgn.Select(p => new SelectListItem
            //{
            //    Value = p.Id.ToString(),
            //    Text = p.Name

            //}).ToList();
            //return View(model);

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
            try
            {
                if (ModelState.IsValid)
                {
                    var add = await PostAsync<DesignationCreateViewModel>(model, Helper.DesignationGetAll);
                    return RedirectToAction("Index");
                }
                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                DesignationCreateViewModel model1 = new DesignationCreateViewModel();
                model1.Department = Desgn.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                }).ToList();
                model = model1;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            //if(ModelState.IsValid)
            //{
            //    var add = await PostAsync<DesignationCreateViewModel>(model, Helper.DesignationGetAll);
            //    return RedirectToAction("Index");
            //}


        }


        [HttpPost]
        public async Task<IActionResult> Edit(DesignationListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edit = await PutAsync<DesignationListViewModel>(Helper.DesignationEdits, model);
                    return RedirectToAction("Index");
                }

                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                DesignationListViewModel model1 = new DesignationListViewModel();
                model1.Department = Desgn.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

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
        public async Task<IActionResult> DeleteConfirmed(Designation model)
        {
            var del = await DeleteAsync<Designation>(string.Format(Helper.DesignationDeletes, model.Id));

            return RedirectToAction("Index");
        }
    }
}
