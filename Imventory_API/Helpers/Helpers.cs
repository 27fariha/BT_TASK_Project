using Imventory_API.Models.DatabaseMappings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Imventory_API.Helpers
{
    public class Helpers
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // 16 bytes (128 bits) is a common size for salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static byte[] HashPassword(string password, byte[] salt, string type)
        {
            if (type == "sha256")
            {
                using (var sha256 = new SHA256Managed())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                    Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                    Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                    return sha256.ComputeHash(saltedPassword);
                }
            }
            else if (type == "sha1")
            {
                using (var sha1 = new SHA1Managed())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                    Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                    Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                    return sha1.ComputeHash(saltedPassword);
                }
            }
            else
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] byteArray = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return byteArray;
        }


    }
}
