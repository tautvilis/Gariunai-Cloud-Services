using System.Security.Cryptography;

namespace WebApi.Handlers
{
    public interface ISalter
    {
        byte[] CreateSalt();
        byte[] GenerateSaltedHash(string plainText, byte[] salt);
    }
    public class Salter : ISalter
    {
        private static int saltsize = 20;

        byte[] ISalter.CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltsize];
            rng.GetBytes(buff);
            return buff;
        }

        public byte[] GenerateSaltedHash(string plainText, byte[] salt)
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