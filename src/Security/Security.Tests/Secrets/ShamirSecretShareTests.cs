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

        [TestCase("This is a secret", 0, 1, 2)]
        [TestCase("This is a secret", 0, 1, 3)]
        [TestCase("This is a secret", 0, 1, 4)]
        [TestCase("This is a secret", 0, 1, 4)]
        [TestCase("This is a secret", 0, 2, 4)]
        [TestCase("This is a secret", 0, 3, 4)]
        [TestCase("This is a secret", 1, 3, 4)]
        [TestCase("This is a secret", 2, 3, 4)]
        public void Combining_parts_yields_original_secret(string secretString, int a, int b, int c)
        {
            Console.WriteLine($"{secretString} ({secretString.Length})");

            var secret = Encoding.ASCII.GetBytes(secretString);

            var parts = _secretShare.Split(secret, 5, 3).ToList();

            Console.WriteLine("\nGenerated:\n");

            foreach (var part in parts)
            {
                Console.WriteLine($"{part.ToBase64()} {part.ToHex()} ({part.Length})");
            }

            Console.WriteLine("\nCombining:\n");
            Console.WriteLine($"{parts[a].ToBase64()} {parts[a].ToHex()} ({parts[a].Length})");
            Console.WriteLine($"{parts[b].ToBase64()} {parts[b].ToHex()} ({parts[b].Length})");
            Console.WriteLine($"{parts[c].ToBase64()} {parts[c].ToHex()} ({parts[c].Length})");

            var toJoin = new List<byte[]>
                         {
                             parts[a],
                             parts[b],
                             parts[c]
                         };

            var joined = _secretShare.Join(toJoin);

            Console.WriteLine("\nYields:\n");

            Console.WriteLine($"{Encoding.ASCII.GetString(joined)} ({joined.Length})");

            Assert.That(joined, Is.EqualTo(secretString));
        }
    }
}