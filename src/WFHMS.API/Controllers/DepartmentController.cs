using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    private ModelStateDictionary
     ValidationMessages
    { get; set; }




    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentServices departmentServices)
    {
        this._logger = logger;
        this.departmentServices = departmentServices;


    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
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
        return Ok(existing);
    }

    [HttpPost]
    public async Task<IActionResult> Add(DepartmentCreateViewModel department)
    {
        var existingdep = await departmentServices.CheckDuplicateAdd(department);
        if (existingdep != null)
        {
            return BadRequest("Name cannot be repeated! Same Department Name Already Exists in Database");
        }
        else
        {
            await departmentServices.Add(department);
            return Ok();
        }
    }
   
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(DepartmentListViewModel department)
    {
        var existing = await departmentServices.CheckDuplicateUpdate(department);
        if (existing != null)
        {
            return BadRequest("Name cannot be repeated! Same Department Name Already Exists in Database");
        }
        else
        {
            await departmentServices.Update(department);
            return Ok();
        }
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

