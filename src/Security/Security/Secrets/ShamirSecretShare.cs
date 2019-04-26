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
                var polynomial = _gf256.Generate(minimum - 1, secret[i]);

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

            var partCount = partsArray.Length;
            var length = partsArray[0].Length;

            var secret = new byte[length];

            for (var i = 0; i < secret.Length; i++)
            {
                var points = new byte[partCount][];

                for (var j = 0; j < partCount; j++)
                {
                    points[j] = new byte[length];
                }

                var k = 0;
                foreach (var part in partsArray)
                {
                    points[k][0] = (byte) (k + 1);
                    points[k][1] = part[i];
                    k++;
                }

                secret[i] = _gf256.Interpolate(points);
            }

            return secret;
        }
    }
}