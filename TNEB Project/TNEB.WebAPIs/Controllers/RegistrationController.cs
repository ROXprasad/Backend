using Microsoft.AspNetCore.Mvc;
using TNEB.DataModels;
using TNEB.BusinessLogics.Interface;

namespace TNEB.WebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistration _registration;
        private readonly ILogger<EmployeeController> _logger;
        public RegistrationController(IRegistration registration, ILogger<EmployeeController> logger)
        { 
            _registration = registration;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult MyAction()
        {
            _logger.LogInformation("This is an info log message.");
            return Ok();
        }

        [HttpPost]
        [Route("RegistrationForm")]
        public async Task<IActionResult> PostRegistration([FromBody] RegistrationDetails regdetails)
        {
            _logger.LogInformation("This is an Registerationform enters");
            try
            {
                _logger.LogInformation("This is an Registerationform try enters");
                var createdRegistration = await _registration.AddRegistrationAsync(regdetails);
               if (createdRegistration != null)
               {
                    _logger.LogInformation("This is an Registerationform success enters");
                    var responseValue = new { status = "Success", response = createdRegistration, message = "Registration completed successfully!" };
                    return Ok(responseValue);
               }
                else
                {
                    _logger.LogInformation("This is an Registerationform Failed enters");
                    var responseValue = new { status = "Failed", response = createdRegistration, message = "Registration failed. No data found." };
                    return Ok(responseValue);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("This is an Registerationform Internal Server enters");
                return StatusCode(500, "Already Userid Exists: " + ex.Message);
            }
        }
    }
}
