using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class ApplyForWFHController : ControllerBase
    {
        private readonly ILogger<ApplyForWFHController> _logger;
        private readonly IApplyForWFHServices applyForWFHServices;
        

        public ApplyForWFHController(ILogger<ApplyForWFHController> logger, IApplyForWFHServices applyForWFHServices)
        {
            _logger = logger;
            this.applyForWFHServices = applyForWFHServices;
            
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {  
            var apply = applyForWFHServices.GetAll();
            return Ok(apply);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var existing = await applyForWFHServices.GetAsync(id);
            if(existing == null)
            {
                return BadRequest("Id Doesn't Exists!");
            }
            return Ok(existing);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApplyForWFHCreateViewModel applyForWFH)
        {
           
            await applyForWFHServices.Add(applyForWFH);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(ApplyForWFHListViewModel applyForWFH)
        {
            await applyForWFHServices.Update(applyForWFH);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var delt = await applyForWFHServices.GetAsync(id);
            if(delt == null)
            {
                return BadRequest("Id Doesn't Exists!");
            }
            else
            {
                await applyForWFHServices.Delete(delt);
                return Ok();
            }
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
