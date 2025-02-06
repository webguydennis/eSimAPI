using eSimAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eSimAPI.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class eSimController : ControllerBase {
        
        private readonly EsimService _esimService;
        
        public eSimController() {
            // Replace with your actual e-SIM service API base URL
           _esimService = new EsimService("https://esim-api.example.com/");
        }

        [HttpGet("Health")]
        public IActionResult Health() {
            return Ok("Healthy. It Works.");
        }

        [HttpPost("provision")]
        public async Task<IActionResult> ProvisionEsim([FromBody] string activationCode)
        {
            try
            {
                var esimProfile = await _esimService.ProvisionEsimAsync(activationCode);
                return Ok(esimProfile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("activate/{esimId}")]
        public async Task<IActionResult> ActivateEsim(string esimId)
        {
            try
            {
                var success = await _esimService.ActivateEsimAsync(esimId);
                return success ? Ok() : StatusCode(500, "Activation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}