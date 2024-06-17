using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class SHA256HashingExtension
    {
        public static bool CheckHash(this string hash, string value)
        {
            // Check if the hash or value is null or empty
            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(value))
                return false;

            // Create a SHA256
            try
            {
                // ComputeHash - returns byte array
                byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));

                // Convert byte array to a string
                StringBuilder builder = new();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                // Check if the hash matches the value
                return builder.ToString() == hash;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string CreateHash(this string value)
        {
            // Check if the value is null or empty
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            // Create a SHA256

            try
            {
                // ComputeHash - returns byte array
                byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));

                // Convert byte array to a string
                StringBuilder builder = new();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                // Return the hash
                return builder.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
