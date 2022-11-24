using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using System.Net;
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
            try
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
          
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                var edit = await GetAsync<DesignationListViewModel>(String.Format(Helper.DesignationEdits, id));
                if (edit == null)
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

                throw ex;
            }
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
                var add = await PostAsync<DesignationCreateViewModel>(model, Helper.DesignationGetAll);
                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                DesignationCreateViewModel model1 = new DesignationCreateViewModel();
                model1.Department = Desgn.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                }).ToList();
                model = model1;
                if (ModelState.IsValid)
                {
                    if (add.StatusCode == HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", add.Content.ReadAsStringAsync().Result);

                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(DesignationListViewModel model)
        {
            try
            {
                var edit = await PutAsync<DesignationListViewModel>(Helper.DesignationEdits, model);
                var Desgn = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
                DesignationListViewModel model1 = new DesignationListViewModel();
                model1.Department = Desgn.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                }).ToList();
                model = model1;
                if (ModelState.IsValid)
                {
                    
                    if (edit.StatusCode == HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", edit.Content.ReadAsStringAsync().Result);
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
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
