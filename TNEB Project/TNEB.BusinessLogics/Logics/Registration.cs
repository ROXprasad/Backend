using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using TNEB.BusinessLogics.CommonAndInternalClass;
using TNEB.BusinessLogics.Interface;
using TNEB.DataModels;

namespace TNEB.BusinessLogics.Logics
{
    public class Registration : IRegistration
    {
        private readonly string _connectionString;
        private readonly ILogger<Registration> _logger;
        public Registration(IConfiguration configuration, ILogger<Registration> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

       public async Task<RegistrationDetails> AddRegistrationAsync(RegistrationDetails registrationDetails)
        {
            

            _logger.LogInformation("This is an AddRegistrationAsync method enters");
            try
            {
                string encryptedPassword = Encrypt(registrationDetails.pswrd);
                var registration = new RegistrationDetails
                {
                    userid = registrationDetails.userid,
                    emailid = registrationDetails.emailid,
                    mobileno = registrationDetails.mobileno,
                    recordstatus = registrationDetails.recordstatus,
                    portaltype=registrationDetails.portaltype,
                    pswrd = encryptedPassword,
                };
                _logger.LogInformation("This is an AddRegistrationAsync try enters");
                _logger.LogInformation($"This is an AddRegistrationAsync dbconnection enters {_connectionString}");
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = @"INSERT INTO admin_web.registration (userid, emailid, mobileno, recordstatus, portaltype,password) 
                                  VALUES (@UserId, @EmailId, @MobileNo, @RecordStatus, @Portaltype,@pswrd) RETURNING id"; // Assuming 'id' is an auto-increment field
                  
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", registration.userid);
                        command.Parameters.AddWithValue("@EmailId", registration.emailid);
                        command.Parameters.AddWithValue("@MobileNo", registration.mobileno);
                        command.Parameters.AddWithValue("@RecordStatus", registration.recordstatus);
                        command.Parameters.AddWithValue("@Portaltype", registration.portaltype);
                        command.Parameters.AddWithValue("@pswrd", encryptedPassword);

                        var insertedId = await command.ExecuteScalarAsync();
                        registrationDetails.id = Convert.ToInt32(insertedId);
                    }
                   
                    if (registrationDetails !=null)
                    {
                       // await connection.OpenAsync();
                        var querys = @"INSERT INTO admin_web.userlogin (username, password) 
                                  VALUES (@UserId, @pswrd) RETURNING id"; // Assuming 'id' is an auto-increment field
                        using (var command = new NpgsqlCommand(querys, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", registration.userid);
                            command.Parameters.AddWithValue("@pswrd", encryptedPassword);

                            var insertedId = await command.ExecuteScalarAsync();
                           // registrationDetails.id = Convert.ToInt32(insertedId);
                        }

                    }
                }
                _logger.LogInformation($"This is an AddRegistrationAsync catch enters");
                return registrationDetails;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"This is an AddRegistrationAsync catch enters {ex}");
                throw new Exception("Error while adding registration", ex);
            }
         
        }
        public string Encrypt(string password)
        {
            EncryptionDescription enc = new EncryptionDescription('E', password);
            return enc.returndata;
        }
        public string Decrypt(string password)
        {
            EncryptionDescription enc = new EncryptionDescription('D', password);
            return enc.returndata;
        }
    }

}
