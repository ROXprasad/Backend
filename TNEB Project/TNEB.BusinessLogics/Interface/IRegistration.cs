using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNEB.BusinessLogics.Logics;
using TNEB.DataModels;

namespace TNEB.BusinessLogics.Interface
{
    public interface IRegistration
    {
        Task<RegistrationDetails> AddRegistrationAsync(RegistrationDetails registrationDetails);
    }
}
