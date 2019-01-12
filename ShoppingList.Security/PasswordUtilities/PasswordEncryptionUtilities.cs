using System;
using System.Security.Cryptography;

namespace ShoppingList.Security.PasswordUtilities
{
    public static class PasswordEncryptionUtilities
    {
        private const int SaltSize = 8;
        private const int NumIterations = 10000;

        public static HashSalt GenerateSaltedHash(string password)
        {
            var saltBytes = new byte[SaltSize];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, NumIterations);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            var hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, NumIterations);

            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}
