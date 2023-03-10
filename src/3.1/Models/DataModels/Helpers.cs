using System;
using System.Security.Cryptography;
using System.Text;

namespace DataModels
{
    public static class Helpers
    {
        public static string GetHashString(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Пустая строка не пригодна для хэширования", nameof(code));

            var sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(code));

                foreach (var b in result) sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool VerifyHashedString(string? code, string hashedCode)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            code = code.Trim();
            return hashedCode == GetHashString(code);
        }
    }
}