using NUnit.Framework;
using Security.Crypto;
using System.Text;

namespace Security.Tests.Crypto
{
    [TestFixture]
    public class CipherTests
    {
        private ISymmetricCipher _cipher;

        [SetUp]
        public void SetUp()
        {
            _cipher = new SymmetricCipher();
        }

        [Test]
        public void Encrypts_data_and_decrypting_yields_initial_secret()
        {
            var key = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
            var iv = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };
            var salt = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };

            const string secretText = "This is a secret don't you know";

            var secretBytes = Encoding.ASCII.GetBytes(secretText);

            var cipherBytes = _cipher.Encrypt(secretBytes, key, iv, salt);

            Assert.AreNotEqual(secretBytes, cipherBytes);

            var decipheredBytes = _cipher.Decrypt(cipherBytes, key, iv, salt);

            var decipheredText = Encoding.ASCII.GetString(decipheredBytes);

            Assert.AreEqual(decipheredText, secretText);
        }
    }
}