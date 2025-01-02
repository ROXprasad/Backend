using TNEB.BusinessLogics.Interface;
using Npgsql;
using Microsoft.Extensions.Configuration;
using TNEB.BusinessLogics.CommonAndInternalClass;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace TNEB.BusinessLogics.Logics
{
    public class loginService : IloginService
    {
        private readonly IConfiguration config;
        private readonly string _connectionString;
        string Key = string.Empty;
        string Issuer = string.Empty;
        string Audience = string.Empty;

        public loginService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            this.config = configuration;
            Key = config["JWT:Key"];
            Issuer = config["JWT:Issuer"];
            Audience = config["JWT:Audience"];
        }

        public async Task<string> RegisterUser(string username, string password)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string checkUserQuery = "SELECT COUNT(*) FROM admin_web.userlogin WHERE username = @Username";
                using (var cmd = new NpgsqlCommand(checkUserQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int userCount = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    if (userCount > 0) // User already exists
                    {
                        string loginResult = await LoginUser(username, password);
                        return loginResult;
                    }
                }
            }
            string encryptedPassword = Encrypt(password);
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO admin_web.userlogin (username, password) VALUES (@Username, @Password)";
                using(var cmd = new NpgsqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", encryptedPassword);

                    await cmd.ExecuteNonQueryAsync();
                }
                return "User Registered Successfully";
            }
        }

        public async Task<string> LoginUser(string username, string password)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT password FROM admin_web.userlogin WHERE username = @Username";
                string encryptedPassword;
                using(var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    encryptedPassword = (string)await cmd.ExecuteScalarAsync();
                }
                if (string.IsNullOrEmpty(encryptedPassword))
                {
                    return "User not found";
                }

                string decryptedPassword = Decrypt(encryptedPassword);

                if (decryptedPassword == password)
                {
                    string token = GenerateJwtToken(username, Key, Issuer, Audience);
                    return $"Token: {token}";
                }

                return "Invalid password";
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
        private string GenerateJwtToken(string username, string JWTKey, string JWTIssuer, string JWTAudienc)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(JWTKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                   new Claim(ClaimTypes.Name,username),
                 }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = JWTIssuer,
                Audience = JWTAudienc,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}



