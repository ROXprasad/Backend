using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0018 : EmpProfile_SuperSets
    {
        public string RequestedDays { get; set; }
        public DateTime? ClamedON { get; set; }
        public DateTime? AsOn { get; set; }
        public string HRAAmount { get; set; }
        public string CCAAmount { get; set; }
        public string EarnedLeaveAAS { get; set; }
        public string Amount { get; set; }


    }
}
