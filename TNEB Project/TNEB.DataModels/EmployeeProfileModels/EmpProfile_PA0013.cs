using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0013 : EmpProfile_SuperSets
    {
        public string SchemeType { get; set; }
        public string TempCertificateNo1 { get; set; }
        public string ESINumber1 { get; set; }
        public string ESIDispensary { get; set; }
        public string ContributingtoLWF { get; set; }
        public string EligibleforPTax { get; set; }
        public string Sec89Eligibility { get; set; }
        public string ESINumber2 { get; set; }
        public string TempCertificateNo2 { get; set; }
        public string NonResidentCheck { get; set; }
        public string MinimumWageSlab { get; set; }
        public string SignedForm12BB { get; set; }
        public string NoERContrDisable { get; set; }
        public string TaxationOption { get; set; }
        public string TaxationOption_Description { get; set; }
    }
}
