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
            var values = new byte[parts][];

            for (var i = 0; i < parts; i++)
            {
                values[i] = new byte[secret.Length];
            }

            for (var i = 0; i < secret.Length; i++)
            {
                var polynomial = _gf256.Generate(minimum, secret[i]);

                for (var j = 0; j < parts; j++)
                {
                    values[j][i] = _gf256.Evaluate(polynomial, j + 1);
                }
            }

            var result = new List<byte[]>();

            for (var i = 0; i < parts; i++)
            {
                result.Add(values[i]);
            }

            return result;
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