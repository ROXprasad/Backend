using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNEB.DataModels;
using TNEB.DataModels.EmployeeProfileModels;

namespace TNEB.BusinessLogics.Interface
{
    public interface IEmployeeService
    {
        Task<EmpProfile_PA0000> GetActionSetDetailsAsync(string personalno);
        Task<EmpProfile_PA0001> GetorgAssignDetailsAsync(string personalno);
        Task<EmpProfile_PA0002> GetPersonalDetailsAsync(string personalno);
        Task<List<EmpProfile_PA0003>> GetEduDetailsAsync(string personalno);
        Task<EmpProfile_PA0004> GetPersonalChallangesAsync(string personalno);
        Task<List<EmpProfile_PA005>> GetFamilyDetailsAsync(string personalno);
        Task<List<EmpProfile_PA0006>> GetaddressDet_PA0006(string personalno);
        Task<EmpProfile_PA0007> GetPersonalActionAsync(string personalno);
        Task<List<EmpProfile_PA0008>> GetPersonalOrderAsync(string personalno);
        Task<EmpProfile_PA0009> GetPersonalBankDetAsync(string personalno);
        Task<EmpProfile_PA0010> GetPersonalDateSpecificationAsync(string personalno);
        Task<List<EmpProfile_PA0011>> GetPersonalCommunicationAsync(string personalno);
        Task<EmpProfile_PA0012> GetPersonalPFAsync(string personalno);
        Task<EmpProfile_PA0013> GetPersonalOtherStatutoryAsync(string personalno);
        Task<List<EmpProfile_PA0014>> GetPersonalNominationAsync(string personalno);
        Task<List<EmpProfile_PA0015>> GetPersonalTrainingDetAsync(string personalno);
        Task<EmpProfile_PA0016> GetPersonalDepartmentTestAsync(string personalno);
        Task<EmpProfile_PA0017> GetPersonalAwardsAsync(string personalno);
        Task<EmpProfile_PA0018> GetPersonalGoodServicesAsync(string personalno);
        Task<List<EmpProfile_PA0019>> GetPersonalIDAsync(string personalno);
        Task<PostImage> GetImageAsync(string personalno);


    }
}
