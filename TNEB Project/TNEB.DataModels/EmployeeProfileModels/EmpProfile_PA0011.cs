using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0011 : EmpProfile_SuperSets
    {
        public string Type { get; set; }
        public string Type_Description { get; set; }
        public string SystemID { get; set; }
        public string LongIDNumber { get; set; }
    }
    public class CommunicationResponse
    {
        public CR d { get; set; }
    }
    public class CR
    {
        public List<EmpProfile_PA0011> results { get; set; }
    }
}
