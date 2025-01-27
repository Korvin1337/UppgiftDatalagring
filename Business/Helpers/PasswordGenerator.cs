using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

public class PasswordGenerator
{

    public (string securePassword, string securityKey) Generate(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException("password cannot be null or empty.", nameof(password));

        var salt = GenerateSalt();

        string securePassword = HashPassword(password, salt);
        string securityKey = Convert.ToBase64String(salt);

        return (securePassword, securityKey);
    }

    private byte[] GenerateSalt(int size = 16)
    {
        var salt = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private string HashPassword(string password, byte[] salt)
    {
        using var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
        byte[] hash = rfc2898.GetBytes(32);
        return Convert.ToBase64String(hash);
    }
}
