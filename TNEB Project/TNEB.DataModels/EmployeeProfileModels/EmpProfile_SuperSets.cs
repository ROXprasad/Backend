using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_SuperSets
    {
        public string PersonnelNo { get; set; }
        public string Infotype { get; set; }
        public string ObjectID { get; set; }
        public string Lockindicator { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string subtype { get; set; }
        public string subtype_desrciption { get; set; }
        public string ITrecordno { get; set; }
        public string Action { get; set; }
        public DateTime? ChangedOn { get; set; }
        public string Changedby { get; set; }
        public string Historicalrec { get; set; }
        public bool Textexists { get; set; }
        public bool Refexists { get; set; }
        public bool Conffieldsex { get; set; }
        public string Screencontrol { get; set; }
        public string ChangeReason { get; set; }
        public string ReservedField1 { get; set; }
        public string ReservedField2 { get; set; }
        public string ReservedField3 { get; set; }
        public string ReservedField4 { get; set; }
        public string ReservedFieldLen2_1 { get; set; }
        public string ReservedFieldLen2_2 { get; set; }
        public string GroupingValue { get; set; }
    }
}