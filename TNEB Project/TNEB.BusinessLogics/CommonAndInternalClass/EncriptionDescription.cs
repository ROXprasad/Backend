using System.Security.Cryptography;
using System.Text;

namespace TNEB.BusinessLogics.CommonAndInternalClass
{
    public class EncryptionDescription
    {
        public string? returndata { get; set; }

        public EncryptionDescription(char type, string data)
        {
            string keyofecndec = "blackboxwaxcode";
            try
            {
                if (type == 'E')
                {
                    byte[] clearBytes = Encoding.Unicode.GetBytes(data);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(keyofecndec, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(clearBytes, 0, clearBytes.Length);
                                cs.Close();
                            }
                            returndata = Convert.ToBase64String(ms.ToArray());

                        }

                    }
                }

                if (type == 'D')
                {
                    data = data.Replace(" ", "+");
                    byte[] clearBytes = Convert.FromBase64String(data);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(keyofecndec, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(clearBytes, 0, clearBytes.Length);
                                cs.Close();
                            }
                            returndata = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch
            {
                returndata = null;
            }
        }
    }
}
