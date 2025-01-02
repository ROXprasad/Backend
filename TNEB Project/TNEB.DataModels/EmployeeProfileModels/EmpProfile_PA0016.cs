using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0016 : EmpProfile_SuperSets
    {
        public string TestCode { get; set; }
        public string DepartmentTestDetails { get; set; }
        public DateTime? StartDate1 { get; set; }
        public string Status { get; set; }
    }

}
