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

    [HttpGet]
    public async Task<IActionResult>GetAll()
    {
       var dep = await departmentServices.GetAll();
       return Ok(dep);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var existing = await departmentServices.GetAsync(id);

        if (existing == null)
        {
            return BadRequest("Id Doesn't Exists!");
        }
        
        //ViewBag.departmentList = new SelectList(departmentServices.GetAsync(), "Id", "Name");
        return Ok(existing);
    }

    [HttpPost]
    public async Task<IActionResult> Add(DepartmentCreateViewModel department)
    {
      if(ModelState.IsValid)
        {
            await departmentServices.Add(department);
            return Ok();
        }
        else
        {
            return BadRequest("Name cannot be repeated!");
        }
        //await departmentServices.Add(department);
        //return Ok();
        
        
    }
   


    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(DepartmentListViewModel department)
    {
        await departmentServices.Update(department);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var del = await departmentServices.GetAsync(id);
        if (del == null)
        {
            return NotFound();
        }
        else
        {
            await departmentServices.Delete(del);
            return Ok();
        }


    }










}

