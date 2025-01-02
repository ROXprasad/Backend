using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TNEB.DataModels.EmployeeProfileModels;
using Microsoft.Extensions.Configuration;


namespace TNEB.SAPInterface
{
    public class SAPOData_EmployeeProfile
    {
        private readonly HttpClient _httpClient;
        private readonly string HostPort;
        private readonly byte[] byteArray;
        private readonly string _sapUrl;
        private readonly string _password;
        private readonly string _format;
        string requestUri;
        public SAPOData_EmployeeProfile(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _sapUrl = configuration["SAPURL"];
            _password = configuration["Password"];
            _format = configuration["JSON"];
            byteArray = Encoding.ASCII.GetBytes(_password);
           
        }

        private async Task<string> SendGetRequestAsync(string requestUri, string personalno)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("personnelno", personalno);
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception($"Error retrieving data from SAP: {response.ReasonPhrase}");
        }
        public async Task<string> GetActionSetDetailsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0000_ActionSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }

        public async Task<string> GetorgAssignDetailsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0001_EmployeeOrgDetailsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }

        public async Task<string> GetPersonalDetailsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0002_PersonalDetailsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetEduDetailsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0022_EducationSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }

        public async Task<string> GetPersonalChallangesAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0004_ChallengesSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetFamilyDetailsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0021_FamilyMembersSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetaddressDet_PA0006(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0006_AddressSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalActionAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0000_ActionSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalOrderAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA9003_OrderSet{_format}";//
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetBankDetAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0009_BankDetailsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalDateSpecificationAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0041_DateSpecificationSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalCommunicationAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0105_CommunicationSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalPFAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0587_PFSet{_format}";//&sap-client=110http://<HOST:PORT>/sap/opu/odata/sap/ZAPI_HCM_ESSMSS_001_SRV/PA0587_PFSet
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalOtherStatutoryAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0588_OtherStatutorySet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalNominationAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0591_NominationSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalTrainingDetAsync(string personalno)
        {
            requestUri = $"{ _sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/ PA9000_TrainingDetailsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }

        public async Task<string> GetDepartmentTestAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA9001_DepartmentTestSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalAwardsAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA9005_AwardsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalGoodServicesAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA9024_LeaveEncashmentSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetPersonalIDAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PA0185_PersonalIDsSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }
        public async Task<string> GetImageAsync(string personalno)
        {
            requestUri = $"{_sapUrl}/ZAPI_HCM_ESSMSS_001_SRV/PhotoSet{_format}";
            return await SendGetRequestAsync(requestUri, personalno);
        }


    }



}

