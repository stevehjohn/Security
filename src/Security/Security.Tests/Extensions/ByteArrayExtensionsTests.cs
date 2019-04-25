using NUnit.Framework;
using Security.Extensions;

namespace Security.Tests.Extensions
{
    public class ByteArrayExtensionsTests
    {
        [Test]
        public void ToBase64_encodes_correctly()
        {
            var bytes1 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var bytes2 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            var bytes3 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
            var bytes4 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

            Assert.That(bytes1.ToBase64(), Is.EqualTo("AAECAwQFBgcICQoLDA0ODxAREhMU"));
            Assert.That(bytes2.ToBase64(), Is.EqualTo("AAECAwQFBgcICQoLDA0ODxAREhMUFQ=="));
            Assert.That(bytes3.ToBase64(), Is.EqualTo("AAECAwQFBgcICQoLDA0ODxAREhMUFRY="));
            Assert.That(bytes4.ToBase64(), Is.EqualTo("AAECAwQFBgcICQoLDA0ODxAREhMUFRYX"));
        }

        [Test]
        public void ToHex_encodes_correctly()
        {
            var bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.That(bytes.ToHex(), Is.EqualTo("000102030405060708090A0B0C0D0E0F1011"));
        }
    }
}