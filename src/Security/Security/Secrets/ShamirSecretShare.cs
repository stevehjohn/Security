using Security.Extensions;
using Security.Random;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<string> Split(byte[] secret, int parts, int minimum, ByteEncoding encoding)
        {
            var secrets = Split(secret, parts, minimum);

            var result = new List<string>();

            foreach (var item in secrets)
            {
                result.Add(encoding == ByteEncoding.Base64
                               ? item.ToBase64()
                               : item.ToHex());
            }

            return result;
        }

        public IEnumerable<string> Split(string secret, int parts, int minimum, ByteEncoding encoding)
        {
            return Split(Encoding.Unicode.GetBytes(secret), parts, minimum, encoding);
        }
    }
}