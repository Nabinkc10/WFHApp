using Microsoft.AspNetCore.Mvc;
using WFHMS.Services.Services;
using WFHMS.Models.ViewModel;

namespace WFHMS.API.Controllers
{
    [ApiController]

   // [Route("api/[controiller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService employeeServices;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeServices)
        {
            _logger = logger;
            this.employeeServices = employeeServices;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var emp = employeeServices.GetAll();
            return Ok(emp);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeCreateViewModel employee)
        {
            await employeeServices.Add(employee);
            return Ok(employee);
        }
    }

}