using NUnit.Framework;
using Security.CustomEncoding;

namespace Security.Tests.CustomEncoding
{
    [TestFixture]
    public class EncoderTests
    {
        [Test]
        public void Base16_property_returns_correct_encoder()
        {
            Assert.That(Encoder.Base16.GetString(new byte[] { 1, 2, 4, 8, 16, 32, 64, 128}).ToUpper(), Is.EqualTo("ACADAGAMCADAGAMA"));
        }
    }
}