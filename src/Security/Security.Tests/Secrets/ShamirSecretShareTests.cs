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

        [Test]
        public void Test()
        {
            var secret = Encoding.Unicode.GetBytes("This is a secret");

            var parts = _secretShare.Split(secret, 5, 3).ToList();

            foreach (var part in parts)
            {
                Console.WriteLine(part.ToBase64());
            }

            var toJoin = new List<byte[]>
                         {
                             parts[0],
                             parts[2],
                             parts[4]
                         };

            var joined = _secretShare.Join(toJoin);

            Console.WriteLine(Encoding.Unicode.GetString(joined));
        }
    }
}