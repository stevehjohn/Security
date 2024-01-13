using NUnit.Framework;
using Security.CustomEncoding;

namespace Security.Tests.CustomEncoding
{
    [TestFixture]
    public class Base16EncoderTests
    {
        private IEncoder _encoder;

        [SetUp]
        public void SetUp()
        {
            _encoder = Encoder.Base16;
        }

        [TestCase(new byte[] { 1 }, "AC")]
        [TestCase(new byte[] { 2 }, "AD")]
        [TestCase(new byte[] { 3 }, "AF")]
        [TestCase(new byte[] { 4 }, "AG")]
        [TestCase(new byte[] { 5 }, "AH")]
        [TestCase(new byte[] { 6 }, "AJ")]
        [TestCase(new byte[] { 7 }, "AK")]
        [TestCase(new byte[] { 8 }, "AM")]
        [TestCase(new byte[] { 9 }, "AN")]
        [TestCase(new byte[] { 10 }, "AR")]
        [TestCase(new byte[] { 11 }, "AT")]
        [TestCase(new byte[] { 12 }, "AU")]
        [TestCase(new byte[] { 13 }, "AV")]
        [TestCase(new byte[] { 14 }, "AW")]
        [TestCase(new byte[] { 15 }, "AX")]
        [TestCase(new byte[] { 16 }, "CA")]
        [TestCase(new byte[] { 17 }, "CC")]
        [TestCase(new byte[] { 18 }, "CD")]
        [TestCase(new byte[] { 19 }, "CF")]
        [TestCase(new byte[] { 32 }, "DA")]
        [TestCase(new byte[] { 64 }, "GA")]
        [TestCase(new byte[] { 128 }, "MA")]
        public void GetString_encodes_bytes_correctly(byte[] input, string expected)
        {
            Assert.That(_encoder.GetString(input).ToUpper(), Is.EqualTo(expected));
        }

        [TestCase("AC", new byte[] { 1 })]
        [TestCase("AD", new byte[] { 2 })]
        [TestCase("AF", new byte[] { 3 })]
        [TestCase("AG", new byte[] { 4 })]
        [TestCase("AH", new byte[] { 5 })]
        [TestCase("AJ", new byte[] { 6 })]
        [TestCase("AK", new byte[] { 7 })]
        [TestCase("AM", new byte[] { 8 })]
        [TestCase("AN", new byte[] { 9 })]
        [TestCase("AR", new byte[] { 10 })]
        [TestCase("AT", new byte[] { 11 })]
        [TestCase("AU", new byte[] { 12 })]
        [TestCase("AV", new byte[] { 13 })]
        [TestCase("AW", new byte[] { 14 })]
        [TestCase("AX", new byte[] { 15 })]
        [TestCase("CA", new byte[] { 16 })]
        [TestCase("CC", new byte[] { 17 })]
        [TestCase("CD", new byte[] { 18 })]
        [TestCase("CF", new byte[] { 19 })]
        [TestCase("DA", new byte[] { 32 })]
        [TestCase("GA", new byte[] { 64 })]
        [TestCase("MA", new byte[] { 128 })]
        public void GetBytes_decodes_bytes_correctly(string input, byte[] expected)
        {
            Assert.That(_encoder.GetBytes(input), Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 1, 3, 62, 12, 65, 254, 98, 156})]
        public void Byte_arrays_can_be_encoded_and_decoded(byte[] input)
        {
            var encoded = _encoder.GetString(input);

            var decoded = _encoder.GetBytes(encoded);

            Assert.That(decoded, Is.EqualTo(input));
        }
    }
}