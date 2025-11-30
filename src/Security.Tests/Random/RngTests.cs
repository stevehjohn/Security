using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Security.Random;

namespace Security.Tests.Random;

[TestFixture]
[SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance")]
public class RngTests
{
    private IRng _rng;

    [SetUp]
    public void SetUp()
    {
        _rng = new Rng();
    }

    [Test]
    public void GetBytes_returns_different_data_on_subsequent_calls()
    {
        var first = new byte[100];
        var second = new byte[100];

        _rng.GetBytes(first);
        _rng.GetBytes(second);

        Assert.That(first, Is.Not.EqualTo(second));
    }
}