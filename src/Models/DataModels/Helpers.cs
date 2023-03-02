using System.Security.Cryptography;
using System.Text;

namespace DataModels;

public static class Helpers
{
    public static string GetHashString(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Пустая строка не пригодна для хэширования", nameof(code));

        return string.Concat(SHA256.HashData(
            Encoding.UTF8.GetBytes(code.Trim())).Select(x => x.ToString("X2")));
    }

    public static bool VerifyHashedString(string? code, string hashedCode)
    {
        if (string.IsNullOrWhiteSpace(code)) return false;
        code = code.Trim();
        return hashedCode == GetHashString(code);
    }
}