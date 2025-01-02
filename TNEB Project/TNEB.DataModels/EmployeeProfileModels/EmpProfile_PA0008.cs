using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0008 : EmpProfile_SuperSets
    {
        public string StartDate1 { get; set; }
        public string EndDate1 { get; set; }
        public string UndefinedRange { get; set; }
        public string OrgUnitShortText { get; set; }
        public string Remarks { get; set; }
        public string PositionID { get; set; }
        public string IssueAuthority { get; set; }
        public string DeputationType { get; set; }
        public string DeputationType_Description { get; set; }
        public string AdditionalCharge { get; set; }
        public string AdditionalProcess { get; set; }
        public string Description { get; set; }
        public string DiversionType { get; set; }
        public string DiversionType_Description { get; set; }
        public string Diversion { get; set; }

    }
    public class PersonalOrderResponse
    {
        public PO d { get; set; }
    }
    public class PO
    {
        public List<EmpProfile_PA0008> results { get; set; }
    }

}
