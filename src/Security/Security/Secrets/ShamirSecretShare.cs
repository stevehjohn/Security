using Security.Random;
using System.Collections.Generic;

namespace Security.Secrets
{
    public class ShamirSecretShare : IShamirSecretShare
    {
        private readonly IRng _rng;

        public ShamirSecretShare(IRng rng)
        {
            _rng = rng;
        }

        public IEnumerable<byte[]> Split(byte[] secret, int parts, int minimum)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Split(string secret, int parts, int minimum, ByteEncoding encoding = ByteEncoding.Base64)
        {
            throw new System.NotImplementedException();
        }
    }
}