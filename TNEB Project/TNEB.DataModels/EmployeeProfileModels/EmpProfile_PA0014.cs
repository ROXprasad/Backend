using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0014 : EmpProfile_SuperSets
    {
        public string BenefitType { get; set; }
        public string BenefitType_Description { get; set; }
        public string NomName { get; set; }
        public string Nomaddress1 { get; set; }
        public string Relationship1 { get; set; }
        public DateTime? BirthDate1 { get; set; }
        public string SharePercnt1 { get; set; }
        public string GuardianAddr1 { get; set; }
        public string Nomname2 { get; set; }
        public string Nomaddress2 { get; set; }
        public string Relationship2 { get; set; }
        public DateTime? BirthDate2 { get; set; }
        public string SharePercnt2 { get; set; }
        public string GuardianAddr2 { get; set; }
        public string Nomname3 { get; set; }
        public string Nomaddress3 { get; set; }
        public string Relationship3 { get; set; }
        public string BirthDate3 { get; set; }
        public string SharePercnt3 { get; set; }
        public string GuardianAddr3 { get; set; }
        public string Nomname4 { get; set; }
        public string Nomaddress4 { get; set; }
        public string Relationship4 { get; set; }
        public string BirthDate4 { get; set; }
        public string SharePercnt4 { get; set; }
        public string GuardianAddr4 { get; set; }
        public string Nomname5 { get; set; }
        public string Nomaddress5 { get; set; }
        public string Relationship5 { get; set; }
        public string BirthDate5 { get; set; }
        public string SharePercnt5 { get; set; }
        public string GuardianAddr5 { get; set; }


    }
    public class NominationResponse
    {
        public NR d { get; set; }
    }
    public class NR
    {
        public List<EmpProfile_PA0014> results { get; set; }
    }
}
