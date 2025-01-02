using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfileWrapResponse<T>
    {
        public ResponseData<T> d { get; set; }
    }
    public class ResponseData<T>
    {
        public List<T> results { get; set; }
    }
}
