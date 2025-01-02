using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0017 : EmpProfile_SuperSets
    {
        public string AwardDetails { get; set; }
        public DateTime? StartDate1 { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateofJoiningBoa { get; set; }
        public DateTime? Dateofcompleting2 { get; set; }
        public string Remark { get; set; }
    }
}
