using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ResumeSearch.Web.Security
{
    public static class SecurityHelpers
    {
        public static string EncryptPassword(string password, string salt)
        {            
            //we use codepage 1252 because that is what sql server uses
            byte[] pwdBytes = Encoding.GetEncoding(1252).GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);
            var salted = AppendSaltToPassword(pwdBytes, saltBytes);
            using (var hash = SHA256.Create())
            {
                byte[] hashBytes = hash.ComputeHash(salted);
                return Encoding.GetEncoding(1252).GetString(hashBytes);
            }
            
        }
        public static string CreateSalt()
        {
            byte[] salt = new byte[32];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        private static byte[] AppendSaltToPassword(byte[] password, byte[] salt)
        {
            return password.Concat(salt).ToArray();
        }
    }
}