using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0012 : EmpProfile_SuperSets
    {
        public string EmployeePFNumber1 { get; set; }
        public string EEPensionNumber1 { get; set; }
        public string EEVPFContrPct { get; set; }
        public string EEPFBasis { get; set; }
        public string ERPFBasis { get; set; }
        public string ERPensionBasis { get; set; }
        public string ContrgtoPension { get; set; }
        public string PFTrust { get; set; }
        public string PFTrust_Description { get; set; }
        public string PensionTrust { get; set; }
        public string PFAmount { get; set; }
        public string Currency { get; set; }
        public string EEVPFContrAmt { get; set; }
        public string EmployeePFNumber2 { get; set; }
        public string EEPensionNumber2 { get; set; }
        public string EmprNPSContr { get; set; }
        public string EmprNPSFlag { get; set; }
        public string EmprNPSPercentage { get; set; }
        public string EmpNPSContr { get; set; }
        public string EmpNPSFlag { get; set; }
        public string EmpNPSPercentage { get; set; }
        public string InternationalWorker { get; set; }
        public string GovtPension { get; set; }
        public string PensionAge { get; set; }
        public string WomenContrEndDt { get; set; }
        public string GovtPFContri { get; set; }

    }
}
