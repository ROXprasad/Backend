using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TNEB.BusinessLogics.Interface;
using TNEB.DataModels;
using TNEB.SAPInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using TNEB.DataModels.EmployeeProfileModels;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TNEB.BusinessLogics.Logics
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SAPOData_EmployeeProfile _sAPOData_EmployeeProfile;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(SAPOData_EmployeeProfile sAPOData_EmployeeProfile, ILogger<EmployeeService> logger)
        {
            _sAPOData_EmployeeProfile = sAPOData_EmployeeProfile;
            _logger = logger;
        }

        private async Task<T> GetDetailsAsync<T>(Func<string, Task<string>> getDataFunc, string personalno) where T : class
        {
            try
            {
                var jsonString = await getDataFunc(personalno);
                var dynamicObject = JsonConvert.DeserializeObject<EmpProfileWrapResponse<T>>(jsonString);
                if (dynamicObject?.d?.results?.Count > 0 && dynamicObject?.d?.results != null)
                {
                    return dynamicObject.d.results.FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching personal details", ex);
            }
        }
        public async Task<EmpProfile_PA0000> GetActionSetDetailsAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0000>(_sAPOData_EmployeeProfile.GetActionSetDetailsAsync, personalno);
        }

        public async Task<EmpProfile_PA0001> GetorgAssignDetailsAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0001>(_sAPOData_EmployeeProfile.GetorgAssignDetailsAsync, personalno);
        }

        public async Task<EmpProfile_PA0002> GetPersonalDetailsAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0002>(_sAPOData_EmployeeProfile.GetPersonalDetailsAsync, personalno);
        }
        public async Task<List<EmpProfile_PA0003>> GetEduDetailsAsync(string personalno)
        {
            //return await GetDetailsAsync<EmpProfile_PA0003>(_sAPOData_EmployeeProfile.GetEduDetailsAsync, personalno);
            // Fetch the raw JSON response from the API
            var rawDatas = await _sAPOData_EmployeeProfile.GetEduDetailsAsync(personalno);
            _logger.LogInformation($"{rawDatas}");
            // Deserialize the raw data into the wrapper class
            var response = JsonConvert.DeserializeObject<EducationalDetailsResponse>(rawDatas);

            // Return the list of family members (results)
            return response?.d?.results ?? new List<EmpProfile_PA0003>();
        }

        public async Task<EmpProfile_PA0004> GetPersonalChallangesAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0004>(_sAPOData_EmployeeProfile.GetPersonalChallangesAsync, personalno);
        }
        public async Task<List<EmpProfile_PA005>> GetFamilyDetailsAsync(string personalno)
        {
            //return await GetDetailsAsync<EmpProfile_PA005>(_sAPOData_EmployeeProfile.GetFamilyDetailsAsync, personalno);
            // Fetch the raw JSON response from the API
            var rawData = await _sAPOData_EmployeeProfile.GetFamilyDetailsAsync(personalno);

            // Deserialize the raw data into the wrapper class
            var response = JsonConvert.DeserializeObject<FamilyDetailsResponse>(rawData);

            // Return the list of family members (results)
            return response?.d?.results ?? new List<EmpProfile_PA005>();
        }
        public async Task<List<EmpProfile_PA0006>> GetaddressDet_PA0006(string personalno)
        {
            //return await GetDetailsAsync<EmpProfile_PA005>(_sAPOData_EmployeeProfile.GetFamilyDetailsAsync, personalno);
            // Fetch the raw JSON response from the API
            var rawData = await _sAPOData_EmployeeProfile.GetaddressDet_PA0006(personalno);

            // Deserialize the raw data into the wrapper class
            var response = JsonConvert.DeserializeObject<AddressDetailsResponse>(rawData);

            // Return the list of family members (results)
            return response?.d?.results ?? new List<EmpProfile_PA0006>();
        }
        public async Task<EmpProfile_PA0007> GetPersonalActionAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0007>(_sAPOData_EmployeeProfile.GetPersonalActionAsync, personalno);

        }
        public async Task<List<EmpProfile_PA0008>> GetPersonalOrderAsync(string personalno)
        {

            //return await GetDetailsAsync<EmpProfile_PA005>(_sAPOData_EmployeeProfile.GetFamilyDetailsAsync, personalno);
            // Fetch the raw JSON response from the API
            var rawData = await _sAPOData_EmployeeProfile.GetPersonalOrderAsync(personalno);

            // Deserialize the raw data into the wrapper class
            var response = JsonConvert.DeserializeObject<PersonalOrderResponse>(rawData);

            // Return the list of family members (results)
            return response?.d?.results ?? new List<EmpProfile_PA0008>();

        }
        public async Task<EmpProfile_PA0009> GetPersonalBankDetAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0009>(_sAPOData_EmployeeProfile.GetBankDetAsync, personalno);

        }
        public async Task<EmpProfile_PA0010> GetPersonalDateSpecificationAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0010>(_sAPOData_EmployeeProfile.GetPersonalDateSpecificationAsync, personalno);

        }
        public async Task<List<EmpProfile_PA0011>> GetPersonalCommunicationAsync(string personalno)
        {
            var rawData = await _sAPOData_EmployeeProfile.GetPersonalCommunicationAsync(personalno);

            var response = JsonConvert.DeserializeObject<CommunicationResponse>(rawData);

            return response?.d?.results ?? new List<EmpProfile_PA0011>();


        }
        public async Task<EmpProfile_PA0012> GetPersonalPFAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0012>(_sAPOData_EmployeeProfile.GetPersonalPFAsync, personalno);
        }
        public async Task<EmpProfile_PA0013> GetPersonalOtherStatutoryAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0013>(_sAPOData_EmployeeProfile.GetPersonalOtherStatutoryAsync, personalno);
        }
        public async Task<List<EmpProfile_PA0014>> GetPersonalNominationAsync(string personalno)
        {
            var rawData = await _sAPOData_EmployeeProfile.GetPersonalNominationAsync(personalno);

            var response = JsonConvert.DeserializeObject<NominationResponse>(rawData);

            return response?.d?.results ?? new List<EmpProfile_PA0014>();

        }
        public async Task<List<EmpProfile_PA0015>> GetPersonalTrainingDetAsync(string personalno)
        {
            var rawData = await _sAPOData_EmployeeProfile.GetPersonalTrainingDetAsync(personalno);

            var response = JsonConvert.DeserializeObject<TrainingResponse>(rawData);

            return response?.d?.results ?? new List<EmpProfile_PA0015>();

        }
        public async Task<EmpProfile_PA0016> GetPersonalDepartmentTestAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0016>(_sAPOData_EmployeeProfile.GetDepartmentTestAsync, personalno);

        }
        public async Task<EmpProfile_PA0017> GetPersonalAwardsAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0017>(_sAPOData_EmployeeProfile.GetPersonalAwardsAsync, personalno);

        }
        public async Task<EmpProfile_PA0018> GetPersonalGoodServicesAsync(string personalno)
        {
            return await GetDetailsAsync<EmpProfile_PA0018>(_sAPOData_EmployeeProfile.GetPersonalGoodServicesAsync, personalno);

        }
        public async Task<List<EmpProfile_PA0019>> GetPersonalIDAsync(string personalno)
        {
            var rawData = await _sAPOData_EmployeeProfile.GetPersonalIDAsync(personalno);

            var response = JsonConvert.DeserializeObject<IDResponse>(rawData);

            return response?.d?.results ?? new List<EmpProfile_PA0019>();

        }
        public async Task<PostImage> GetImageAsync(string personalno)
        {
            var data = await _sAPOData_EmployeeProfile.GetImageAsync(personalno);
            return await GetDetailsAsync<PostImage>(_sAPOData_EmployeeProfile.GetImageAsync, personalno);


        }





    }
}

