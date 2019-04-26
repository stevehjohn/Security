using NUnit.Framework;
using Security.Extensions;
using Security.Random;
using Security.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Security.Tests.Secrets
{
    [TestFixture]
    public class ShamirSecretShareTests
    {
        private IRng _rng;
        private IGf256 _gf256;
        private IShamirSecretShare _secretShare;

        [SetUp]
        public void SetUp()
        {
            _rng = new Rng();
            _gf256 = new Gf256(_rng);

            _secretShare = new ShamirSecretShare(_gf256);
        }

        [TestCase("This is a secret")]
        public void Test(string secretString)
        {
            Console.WriteLine($"{secretString} ({secretString.Length})");

            var secret = Encoding.ASCII.GetBytes(secretString);

            var parts = _secretShare.Split(secret, 5, 3).ToList();

            foreach (var part in parts)
            {
                Console.WriteLine($"{part.Key}: {part.Value.ToBase64()} {part.Value.ToHex()} ({part.Value.Length})");
            }

            var toJoin = new Dictionary<int, byte[]>
                         {
                             { parts[0].Key, parts[0].Value },
                             { parts[3].Key, parts[3].Value },
                             { parts[4].Key, parts[4].Value }
                         };

            var joined = _secretShare.Join(toJoin);

            Console.WriteLine($"{Encoding.ASCII.GetString(joined)} ({joined.Length})");
        }
    }
}