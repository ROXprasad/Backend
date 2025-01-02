using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0007 : EmpProfile_SuperSets
    {
        public string ActionType { get; set; }
        public string ActionType_Description { get; set; }
        public string ReasonfAction { get; set; }
        public string ReasonfAction_Description { get; set; }
        public string Customer_specific { get; set; }
        public string Employment { get; set; }
        public string Employment_Description { get; set; }
        public string Specialpayment { get; set; }
    }
}
