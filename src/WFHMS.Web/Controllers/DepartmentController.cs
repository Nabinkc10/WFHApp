﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Differencing;
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
        //public JsonResult IsDepartmentNameExist(string Name)
        //{
        //    string query = "select * from Department where DepartmentId = {0}"
        //    return Json();
        //}
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var edit = await GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentEdits, id));
                if(edit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(edit);
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "Unable to do this Task..Please contat your admin");
                return View("Edit");
            }
            //return View(edit);
            //var edit = await GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentEdits, id));
            //return View(edit);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var Delt = GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentDeletes, id)).Result;
            return View(Delt);
        }
        [HttpPost]
        public async Task<IActionResult>Create(DepartmentCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                  var add = await PostAsync<DepartmentCreateViewModel>(model, Helper.DepartmentGetAll);
                  return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes..Please contat your admin");
                return View("Create");
            }
            return View("Create");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edit = await PutAsync<DepartmentListViewModel>(Helper.DepartmentEdits, model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes..Please contat your admin");
            }
            return View("Edit");

        }
       
        [HttpPost]
        public async Task<IActionResult> Delete(Department model)
        {
           var del = await DeleteAsync<Department>(string.Format(Helper.DepartmentDeletes, model.Id));

            return RedirectToAction("Index");
        }

    }

}
