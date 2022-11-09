using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers;


[ApiController]

[Route("api/[controller]")]

public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDepartmentServices departmentServices;
    

   


    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentServices departmentServices)
    {
        this._logger = logger;
        this.departmentServices = departmentServices;
        
      
    }

    [HttpGet("getall")]
    public async Task<IActionResult>GetAll()
    {
       var dep = departmentServices.GetAll();
       return Ok(dep);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> Add(DepartmentCreateViewModel department)
    {
         await departmentServices.Add(department);
        return Ok();
        
        
    }
    [HttpGet("getbyId")]
    public async Task<IActionResult> Edit(int id,DepartmentCreateViewModel department)
    {

        var existing = departmentServices.GetAsync(id);

        if (existing == null)
        {
            return RedirectToAction("Index");
        }
        //ViewBag.departmentList = new SelectList(departmentServices.GetAsync(), "Id", "Name");
        return Ok(existing);

    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(DepartmentListViewModel department)
    {
        await departmentServices.Update(department);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id, DepartmentListViewModel department)
    {

        var existing = departmentServices.GetAsync(id);

        if (existing == null)
        {
            return RedirectToAction("Index");
        }
        return Ok(existing);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id,DepartmentListViewModel department)
    {
        var existing = departmentServices.GetAsync(id);
        await departmentServices.Delete(department);
          return Ok();
        
    }










}

