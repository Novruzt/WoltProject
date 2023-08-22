using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.Things
{
    public static class UserPasswordService
    {
        public static string[] CalculateSha256Hash(string password)
        {
            string salt = GenerateSalt();
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputWithSaltBytes = new byte[inputBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(inputBytes, 0, inputWithSaltBytes, 0, inputBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, inputWithSaltBytes, inputBytes.Length, saltBytes.Length);
                hashBytes = sha256.ComputeHash(inputWithSaltBytes);
            }
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return new[] { hashedPassword, salt };
        }
        private static string GenerateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(saltBytes);
        }

        public static bool VerifyPassword(string inputPassword, string storedSalt, string storedHashedPassword)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputPassword);
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputWithSaltBytes = new byte[inputBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(inputBytes, 0, inputWithSaltBytes, 0, inputBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, inputWithSaltBytes, inputBytes.Length, saltBytes.Length);
                hashBytes = sha256.ComputeHash(inputWithSaltBytes);
            }
            string inputHashedPassword = Convert.ToBase64String(hashBytes);
            return storedHashedPassword.Equals(inputHashedPassword);
        }

        public static bool CheckOldPassword(string inputPassword, List<UserOldPassword> oldPasswordList) 
        {

            foreach(var oldPassword in oldPasswordList) 
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputPassword);
                byte[] saltBytes = Convert.FromBase64String(oldPassword.OldPasswordSalt);

                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputWithSaltBytes = new byte[inputBytes.Length + saltBytes.Length];
                    Buffer.BlockCopy(inputBytes, 0, inputWithSaltBytes, 0, inputBytes.Length);
                    Buffer.BlockCopy(saltBytes, 0, inputWithSaltBytes, inputBytes.Length, saltBytes.Length);
                    hashBytes = sha256.ComputeHash(inputWithSaltBytes);
                }
                string inputHashedPassword = Convert.ToBase64String(hashBytes);
                if (oldPassword.OldPasswordHash.Equals(inputHashedPassword))
                    return true; 
            }

            return false;
        }
    }
}
