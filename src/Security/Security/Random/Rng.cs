using System.Security.Cryptography;

namespace Security.Random
{
    public class Rng : IRng
    {
        private readonly RandomNumberGenerator _rng;

        public Rng()
        {
            _rng = new RNGCryptoServiceProvider();
        }

        public byte[] GetBytes(int length)
        {
            var bytes = new byte[length];

            _rng.GetBytes(bytes);

            return bytes;
        }
    }
}