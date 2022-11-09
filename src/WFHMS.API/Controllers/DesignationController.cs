using Microsoft.AspNetCore.Mvc;
using WFHMS.Models.ViewModel;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class DesignationController : ControllerBase
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly IDesignationServices designationServices;


        public DesignationController(ILogger<DesignationController> logger,IDesignationServices designationServices)
        {
            _logger = logger;
            this.designationServices = designationServices;
        }
        [HttpGet("getall")]
        public async Task<IActionResult>GetAll()
        {
            var deg = designationServices.GetAll();
            return Ok(deg);
        }
        [HttpPost("Add")]
        public async Task<IActionResult>Add(DesignationCreateViewModel designation)
        {
            await designationServices.Add(designation);
            return Ok();
        }
        [HttpGet("getbyId")]
        public async Task<IActionResult> Edit(int id,DesignationListViewModel designation)
        {
            var existing = designationServices.GetAsync(id);
            if(existing == null)
            { 
                return RedirectToAction("Index");
            }
            return Ok(existing);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Edit(DesignationListViewModel designation)
        {
            await designationServices.Update(designation);
            return Ok();
        }
    }
}
