using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TNEB.BusinessLogics.Interface;
using TNEB.BusinessLogics.Logics;
using TNEB.DataModels;
using TNEB.DataModels.EmployeeProfileModels;

namespace TNEB.WebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            this.employeeService = employeeService;
            _logger = logger;
        }

        // PERSONAL NO: PA0000 – Personal Action
        [HttpGet("PA0000_ActionSet")]
        public async Task<ActionResult<EmpProfile_PA0000>> GetActionSet_PA0000(string personalno)
        {
            var PA0000_Details = await employeeService.GetActionSetDetailsAsync(personalno);
            return Ok(PA0000_Details);
        }

        //new Method

        // PERSONAL NO: PA0001 – Organization Assignment
        [HttpGet("PA0001_OrgAssignment")]
        public async Task<ActionResult<EmpProfile_PA0001>> GetorgAssign_PA00001(string personalno)
        {
            var PA0001_Details = await employeeService.GetorgAssignDetailsAsync(personalno);
            return Ok(PA0001_Details);
        }
        [HttpPost]
        public IActionResult MyAction()
        {
            _logger.LogInformation("This is an info log message.");
            return Ok();
        }
        // PERSONAL NO: PA0002 – Personal Details
        [HttpGet("PA0002_PersonalDetails")]
        public async Task<ActionResult<EmpProfile_PA0002>> GetpersonalDet_PA0002(string personalno)
        {
            var PA0002_Details = await employeeService.GetPersonalDetailsAsync(personalno);
            return Ok(PA0002_Details);
        }
        [HttpGet("PA0003_EducationDetails")]
        public async Task<ActionResult<List<EmpProfile_PA0003>>> GetpersonalDet_PA0003(string personalno)
        {
            var PA0002_Details = await employeeService.GetEduDetailsAsync(personalno);
            return Ok(PA0002_Details);
        }
        //PERSONAL NO: PA0004 – Personal Challenges
        [HttpGet("PA0004_PersonalChallenges")]
        public async Task<ActionResult<EmpProfile_PA0004>> GetpersonalChallenges_PA0004(string personalno)
        {
            var pA0004_Details = await employeeService.GetPersonalChallangesAsync(personalno);
            return Ok(pA0004_Details);
        }
        [HttpGet("PA0005_FamilyDetails")]
        public async Task<ActionResult<List<EmpProfile_PA005>>> GetpersonalDet_PA0005(string personalno)
        {
            var PA0002_Details = await employeeService.GetFamilyDetailsAsync(personalno);
            return Ok(PA0002_Details);
        }
        [HttpGet("PA0006_AddressDetails")]
        public async Task<ActionResult<List<EmpProfile_PA0006>>> GetaddressDet_PA0006(string personalno)
        {
            var PA0002_Details = await employeeService.GetaddressDet_PA0006(personalno);
            return Ok(PA0002_Details);
        }
        [HttpGet("PA0007_PersonalAction")]
        public async Task<ActionResult<EmpProfile_PA0007>> GetPersonalAction_PA0007(string personalno)
        {
            var PA0007_Details = await employeeService.GetPersonalActionAsync(personalno);
            return Ok(PA0007_Details);
        }
        [HttpGet("PA0008_PersonalOrder")]
        public async Task<ActionResult<List<EmpProfile_PA0008>>> GetPersonalOrder_PA0008(string personalno)
        {
            var PA0008_Details = await employeeService.GetPersonalOrderAsync(personalno);
            return Ok(PA0008_Details);
        }
        [HttpGet("PA0009_PersonalBankDet")]
        public async Task<ActionResult<EmpProfile_PA0009>> GetPersonalBankDet_PA0009(string personalno)
        {
            var PA0009_Details = await employeeService.GetPersonalBankDetAsync(personalno);
            return Ok(PA0009_Details);
        }
        [HttpGet("PA0010_PersonalDateSpecification")]
        public async Task<ActionResult<EmpProfile_PA0010>> GetPersonalDateSpecification_PA0010(string personalno)
        {
            var PA0010_Details = await employeeService.GetPersonalDateSpecificationAsync(personalno);
            return Ok(PA0010_Details);
        }
        [HttpGet("PA0011_PersonalCommunication")]
        public async Task<ActionResult<List<EmpProfile_PA0011>>> GetPersonalCommunication_PA0011(string personalno)
        {
            var PA0011_Details = await employeeService.GetPersonalCommunicationAsync(personalno);
            return Ok(PA0011_Details);
        }
        [HttpGet("PA0012_PersonalPF")]
        public async Task<ActionResult<EmpProfile_PA0012>> GetPersonalPF_PA0012(string personalno)
        {
            var PA0012_Details = await employeeService.GetPersonalPFAsync(personalno);
            return Ok(PA0012_Details);
        }
        [HttpGet("PA0013_PersonalOtherStatutory")]
        public async Task<ActionResult<EmpProfile_PA0013>> GetPersonalOtherStatutoryAsync(string personalno)
        {
            var PA0013_Details = await employeeService.GetPersonalOtherStatutoryAsync(personalno);
            return Ok(PA0013_Details);
        }
        [HttpGet("PA0014_PersonalNomination")]
        public async Task<ActionResult<List<EmpProfile_PA0014>>> GetPersonalNominationAsync(string personalno)
        {
            var PA0014_Details = await employeeService.GetPersonalNominationAsync(personalno);
            return Ok(PA0014_Details);
        }
        [HttpGet("PA0015_PersonalTrainingDet")]
        public async Task<ActionResult<List<EmpProfile_PA0015>>> GetPersonalTrainingDet_PA0015(string personalno)
        {
            var PA0015_Details = await employeeService.GetPersonalTrainingDetAsync(personalno);
            return Ok(PA0015_Details);
        }
        [HttpGet("PA0016_PersonalDepartmentTest")]
        public async Task<ActionResult<EmpProfile_PA0016>> GetPersonalDepartmentTest_PA0016(string personalno)
        {
            var PA0016_Details = await employeeService.GetPersonalDepartmentTestAsync(personalno);
            return Ok(PA0016_Details);
        }
        [HttpGet("PA0017_PersonalAwards")]
        public async Task<ActionResult<EmpProfile_PA0017>> GetPersonalAwards_PA0017(string personalno)
        {
            var PA0017_Details = await employeeService.GetPersonalAwardsAsync(personalno);
            return Ok(PA0017_Details);
        }
        [HttpGet("PA0018_PersonalGoodServices")]
        public async Task<ActionResult<EmpProfile_PA0018>> GetPersonalGoodServicesAsync(string personalno)
        {
            var PA0018_Details = await employeeService.GetPersonalGoodServicesAsync(personalno);
            return Ok(PA0018_Details);
        }
        [HttpGet("PA0019_PersonalID")]
        public async Task<ActionResult<List<EmpProfile_PA0019>>> GetPersonalID_PA0019(string personalno)
        {
            var PA0019_Details = await employeeService.GetPersonalIDAsync(personalno);
            return Ok(PA0019_Details);
        }
        [HttpGet("PostImage")]
        public async Task<ActionResult<PostImage>> GetImageAsync(string personalno)
        {
            var image = await employeeService.GetImageAsync(personalno);
            return Ok(image);
        }


    }
}
