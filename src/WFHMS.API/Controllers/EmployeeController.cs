using Microsoft.AspNetCore.Mvc;
using WFHMS.Services.Services;
using WFHMS.Models.ViewModel;

namespace WFHMS.API.Controllers
{
    [ApiController]

   [Route("api/[controller]")]  
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService employeeServices;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeServices)
        {
            _logger = logger;
            this.employeeServices = employeeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emp = await employeeServices.GetAll();
            return Ok(emp);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var existing = employeeServices.GetAsync(id).Result;
            if (existing == null)
            {
                return BadRequest("Id Doesn't Exists!");
            }
            return Ok(existing);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeCreateViewModel employee)
        {
            await employeeServices.Add(employee);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(EmployeeListViewModel employee)
        {
            await employeeServices.Update(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delt = await employeeServices.GetAsync(id);
            if (delt == null)
            {
                return NotFound();
            }
            else
            {
                await employeeServices.Delete(delt);
                return Ok();
            }
        }
    }

}