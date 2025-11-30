using System.Security.Cryptography;

namespace Security.Random;

public class Rng : IRng
{
    private readonly RandomNumberGenerator _rng;

    public Rng()
    {
        _rng = RandomNumberGenerator.Create();
    }

    public void GetBytes(byte[] bytes)
    {
        _rng.GetBytes(bytes);
    }
}