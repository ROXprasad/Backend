using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0019 : EmpProfile_SuperSets
    {
        public string IDType { get; set; }
        public string IDType_Description { get; set; }
        public string IdentityNumber { get; set; }
        public string OldICNumber { get; set; }
        public string IssuingAuthority { get; set; }
        public string IssuingNumber { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string PlaceofIssue { get; set; }
        public string CountryofIssue { get; set; }
        public string CountryofID { get; set; }
        public string CountryofID_Description { get; set; }
        public string OverrideChksIndic { get; set; }
        public string OverrideChksIndic_Description { get; set; }
        public string ApplicationStatus { get; set; }
        public string SingleMultiple { get; set; }
        public string Rejectreason { get; set; }
        public string Usedfrom { get; set; }
        public string Usedto { get; set; }
        public string LengthofVisa { get; set; }
        public string NextPayment { get; set; }
        public string ApplicationDate { get; set; }
    }
    public class IDResponse
    {
        public IDR d { get; set; }
    }
    public class IDR
    {
        public List<EmpProfile_PA0019> results { get; set; }
    }
}
