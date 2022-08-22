using System;
using System.Security.Cryptography;
using System.Text;

namespace TestProject.Common.Utils
{
    public class Encryptor
    {
        public static string EncryptMD5(string input)
        {
            const string saltKey = "Z1pC0";
            string encrypted = string.Empty;

            using (var md5 = MD5.Create())
            {
                UTF8Encoding encoder = new UTF8Encoding();
                byte[] hashedData = md5.ComputeHash(encoder.GetBytes(string.Concat(saltKey, input)));
                encrypted = Convert.ToBase64String(hashedData);
            }

            return encrypted;
        }
    }
}
