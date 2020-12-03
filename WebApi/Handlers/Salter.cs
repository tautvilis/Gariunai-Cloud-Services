using System;
using System.Security.Cryptography;
using System.Security.Policy;

namespace WebApi.Handlers
{
    public interface ISalter
    {
        byte[] CreateSalt();
        byte[] GenerateSaltedHash(string plainText, byte[] salt,BasicAuthenticationHandler.Hashing func );
    }

    
    public class Salter : ISalter
    {
        private static int saltsize = 20;
        private ISalter _salterImplementation;

        public byte[] CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltsize];
            rng.GetBytes(buff);
            return buff;
        }
        
        public byte[] GenerateSaltedHash(string plainText, byte[] salt, BasicAuthenticationHandler.Hashing func)
        {
            return func(plainText, salt);
        }
    }
}