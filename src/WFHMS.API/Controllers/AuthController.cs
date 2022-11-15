using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WFHMS.Models.ViewModel;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger, IUserServices userServices)
        {
            _userServices = userServices;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
              var result = await _userServices.RegisterUserAsync(model);
                if(result.IsSuccess)
                    return Ok(result);
            }
            return BadRequest("Some Properties are not valid!");

        }
    }
}
