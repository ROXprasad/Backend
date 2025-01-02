using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0003 : EmpProfile_SuperSets
    {
        public string educest { get; set; }
        public string educest_description { get; set; }
        public string instituteloc { get; set; }
        public string country { get; set; }
        public string eductraining { get; set; }
        public string eductraining_description { get; set; }
        public string certificate { get; set; }
        public string certificate_description { get; set; }
        public string durofcourse { get; set; }
        public string timeunitmeas { get; set; }
        public string timeunitmeas_description { get; set; }
        public string brofstudy1 { get; set; }
        public string brofstudy1_description { get; set; }

        public string brofstudy2 { get; set; }
        public string coursefees { get; set; }
        public string currency { get; set; }
        public string planindicator { get; set; }
        public string costobject { get; set; }
        public string repaymntobligation { get; set; }
        public string coursename { get; set; }
        public string courseappraisal { get; set; }
        public string inssccode { get; set; }
        public string facultycode { get; set; }
        public string department { get; set; }
        public string finalgrade { get; set; }
        public string universityboard { get; set; }
        public string registerno { get; set; }
        public string certificateno { get; set; }
        public string passedon { get; set; }
    }
    public class EducationalDetailsResponse
    {
        public ED d { get; set; }
    }

    public class ED
    {
        public List<EmpProfile_PA0003> results { get; set; }
    }
}
