using BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ASP_SpringLibrary.Utils
{
    public class Hash
    {
        // Criptografia BCrypt
        public static string GenerateBCrypt(string text)
        {
            // Configurations
            int workfactor = 10; // 2 ^ (10) = 1024 iterations.

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(text, salt);

            return hash;
        }

        public static bool CompareBCrypt(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }

        // Criptografia MD5
        public static string GenerateMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();

            Byte[] originalBytes = encoder.GetBytes(text);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            text = BitConverter.ToString(encodedBytes).Replace("-", "");
            return text.ToLower();
        }

        public static bool CompareMD5(string text, string hash)
        {
            return (GenerateMD5(text) == hash);
        }
    }
}