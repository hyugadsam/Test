using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BDConection.Security
{
    public static class Hash
    {
        public static string HashPasword(string password)
        {
            try
            {
                var salt = Convert.FromBase64String(ConfigurationManager.AppSettings["EncryptKey"]);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                return Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
