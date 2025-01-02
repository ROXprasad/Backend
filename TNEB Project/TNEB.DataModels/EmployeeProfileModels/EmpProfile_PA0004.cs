using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0004 : EmpProfile_SuperSets
    {
        public string challengegroup { get; set; }
        public string challengegroup_description { get; set; }
        public string degreechallenge1 { get; set; }
        public string challengetype { get; set; }
        public string challengetype_description { get; set; }
        public string creditfactor { get; set; }
        public string officialagency1 { get; set; }
        public string referenceno1 { get; set; }
        public DateTime? challengedate1 { get; set; }
        public string officialagency2 { get; set; }
        public string referenceno2 { get; set; }
        public DateTime? challengedate2 { get; set; }
        public DateTime? iddate { get; set; }
        public string degreechallenge2 { get; set; }
        public string cessionfrom { get; set; }
        public string adminoffice { get; set; }
        public string adminoffloc { get; set; }
        public string verificationtype { get; set; }
    }
}
