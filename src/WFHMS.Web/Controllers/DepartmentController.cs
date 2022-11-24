using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;
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
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var edit = await GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentEdits, id));
                if (edit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(edit);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var Delt = await GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentDeletes, id));
            return View(Delt);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var add = await PostAsync<DepartmentCreateViewModel>(model, Helper.DepartmentGetAll);
                    if (add.StatusCode == HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", add.Content.ReadAsStringAsync().Result);
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                return View("Create");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var edit = await PutAsync<DepartmentListViewModel>(Helper.DepartmentEdits, model);
                    if (edit.StatusCode == HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", edit.Content.ReadAsStringAsync().Result);
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                return View("Edit");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Department model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var del = await DeleteAsync<Department>(string.Format(Helper.DepartmentDeletes, model.Id));
                    if (del.StatusCode == HttpStatusCode.NotFound)
                    {
                        ModelState.AddModelError("", del.Content.ReadAsStringAsync().Result);
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                return View("Delete");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

    }

}
