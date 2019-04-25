using Security.Extensions;
using System.Collections.Generic;
using System.Text;

namespace Security.Secrets
{
    public class ShamirSecretShare : IShamirSecretShare
    {
        private readonly IGf256 _gf256;

        public ShamirSecretShare(IGf256 gf256)
        {
            _gf256 = gf256;
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