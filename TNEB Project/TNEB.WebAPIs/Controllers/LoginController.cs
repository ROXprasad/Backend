using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TNEB.DataModels;
using TNEB.BusinessLogics.Interface;
using TNEB.BusinessLogics.CommonAndInternalClass;
using TNEB.BusinessLogics.Logics;


namespace TNEB.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    { 
        //private readonly IConfiguration config;
        private readonly IloginService _loginService;
        private readonly ILogger<EmployeeController> _logger;
        public LoginController(IloginService loginservice, ILogger<EmployeeController> logger) //, IConfiguration configuration
        {
           this._loginService = loginservice;
            _logger = logger;
            //    this.config = configuration;
        }
         [HttpPost]
        public IActionResult MyAction()
        {
            _logger.LogInformation("This is an info log message.");
            return Ok();
        }
      
        [HttpPost]
        [Route("loginAuthenicate")]
        public async Task<IActionResult> Login([FromBody] loginUsers loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.username) || string.IsNullOrEmpty(loginUser.password))
            {
                return BadRequest("Invalid username or password");
            }
            string isRegistered = await _loginService.LoginUser(loginUser.username, loginUser.password);
          
            if (isRegistered.StartsWith("Token:"))
            {
                string token = isRegistered.Replace("Token:", "").Trim(); // Extract the token
                return Ok(new { message = "Login successful", token });
            }

            // Return the result in one line with Ok or relevant status
            return isRegistered switch
            {
                "Login successful" => Ok(new { message = isRegistered }),
                "Invalid password" => Unauthorized(new { message = isRegistered }),
                "User not found" => NotFound(new { message = isRegistered }),
                "User Registered Successfully" => Ok(new { message = isRegistered }),
                _ => StatusCode(500, new { message = isRegistered }) // For any unexpected result
            };
        }
    }
}
