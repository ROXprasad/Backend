using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0001 : EmpProfile_SuperSets
    {
        public string companycode { get; set; }
        public string companycode_description { get; set; }
        public string personnelarea { get; set; }
        public string personnelarea_description{ get; set; }
        public string eegroup { get; set; }
        public string eegroup_description { get; set; }
        public string eesubgroup { get; set; }
        public string eesubgroup_description { get; set; }
        public string orgkey { get; set; }
        public string businessarea { get; set; }
        public string perssubarea { get; set; }
        public string perssubarea_description { get; set; }
        public string legalperson { get; set; }
        public string payrollarea { get; set; }
        public string payrollarea_description { get; set; }
        public string workcontract { get; set; }
        public string costcenter { get; set; }
        public string orgunit { get; set; }
        public string position { get; set; }
        public string position_description { get; set; }
        public string job { get; set; }
        public string job_description { get; set; }
        public string supervisor { get; set; }
        public string payrolladmin { get; set; }
        public string persadmin { get; set; }
        public string timeadmin { get; set; }
        public string last_firstname { get; set; }
        public string empl_applname { get; set; }
        public string objecttype { get; set; }
        public string group { get; set; }
        public string coarea { get; set; }
        public string fundscenter { get; set; }
        public string fund { get; set; }
        public string functionalarea { get; set; }
        public string grant { get; set; }
        public string segment { get; set; }
        public string budgetperiod { get; set; }
        public string status { get; set; }
        public string single_characterflag { get; set; }

    }
}
