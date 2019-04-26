using System.Collections.Generic;
using System.Linq;

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
                    values[j][i] = _gf256.Evaluate(polynomial, (byte) (j + 1));
                }
            }

            var result = new List<byte[]>();

            for (var i = 0; i < parts; i++)
            {
                result.Add(values[i]);
            }

            return result;
        }

        public byte[] Join(IEnumerable<byte[]> parts)
        {
            var partsArray = parts.ToArray();

            var secret = new byte[partsArray[0].Length];

            for (var i = 0; i < secret.Length; i++)
            {
                var points = new byte[partsArray[0].Length];

                var j = 0;
                foreach (var part in partsArray)
                {
                    points[j] = part[i];
                    j++;
                }

                secret[i] = _gf256.Interpolate(points);
            }

            return secret;
        }
    }
}