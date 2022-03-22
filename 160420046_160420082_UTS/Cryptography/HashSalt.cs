using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// System tambahan
using System.IO;
using System.Security.Cryptography;

namespace Cryptography
{
    public class HashSalt
    {
        public static string Encrypt(string text)
        {
            //buat penjelasan baca
            //https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(text, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool Compare(string hashed, string text)
        {
            byte[] hashedBytes = Convert.FromBase64String(hashed);

            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(text, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            bool success = true;
            for (int i = 0; i < 20; i++)
            {
                if (hashedBytes[i + 16] != hash[i])
                {
                    success = false;
                    break;
                }
            }

            return success;
        }
    }
}
