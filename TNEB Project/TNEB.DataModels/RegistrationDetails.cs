using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels
{
    public class RegistrationDetails
    {
       // [Table("registration", Schema = "admin_web")]
       public int id { get; set; }
       public string userid { get; set; }
       public string emailid { get; set; }
       public string mobileno { get; set; }
       public string portaltype { get; set; }
       public string recordstatus { get; set; }
        public string pswrd { get; set; }

    }
}
