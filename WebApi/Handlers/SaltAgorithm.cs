using System.Security.Cryptography;

namespace WebApi.Handlers
{
    public class SaltAgorithm
    {
        internal byte[] Hash(string plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            var plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (var i = 0; i < plainText.Length; i++) 
                plainTextWithSaltBytes[i] = (byte) plainText[i];
            for (var i = 0; i < salt.Length; i++) 
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        

    }
}