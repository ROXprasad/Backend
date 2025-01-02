using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0015 : EmpProfile_SuperSets
    {
        public string TrainingDetails { get; set; }
        public DateTime? EndDate1 { get; set; }
        public DateTime? StartDate1 { get; set; }
        public string Time { get; set; }
        public string VenueDetails { get; set; }

    }
    public class TrainingResponse
    {
        public TR d { get; set; }
    }
    public class TR
    {
        public List<EmpProfile_PA0015> results { get; set; }
    }
}
