using System.Security.Cryptography;
using System.Text;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BestofBooks
{
    public static class SecurityUtilities
    {
        public static string HashPassword (string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException ("password");
            }
            return GetHashString(password);
        }

        public static bool userLoggedIn (string hash, string password)
        {
            string correctHash = HashPassword(password);
            return hash == HashPassword(password);
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
