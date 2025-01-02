using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNEB.DataModels;

namespace TNEB.BusinessLogics.Interface
{
    public interface IloginService
    {
        Task<string> RegisterUser(string username, string password);
        Task<string> LoginUser(string username, string password);
    }
}