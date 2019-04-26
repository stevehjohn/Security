using NUnit.Framework;
using Security.Random;

namespace Security.Tests.Random
{
    public class RngTests
    {
        private IRng _rng;

        [SetUp]
        public void SetUp()
        {
            _rng = new Rng();
        }

        //[TestCase(10)]
        //[TestCase(100)]
        //public void GetBytes_returns_requested_number_of_bytes(int length)
        //{
        //    var bytes = _rng.GetBytes(length);

        //    Assert.That(bytes.Length, Is.EqualTo(length));
        //}

        //[Test]
        //public void GetBytes_returns_different_data_on_subsequent_calls()
        //{
        //    var first = _rng.GetBytes(100);
        //    var second = _rng.GetBytes(100);

        //    Assert.AreNotEqual(first, second);
        //}
    }
}