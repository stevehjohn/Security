using System.Collections.Generic;

namespace Security.Secrets
{
    public interface IShamirSecretShare
    {
        IDictionary<int, byte[]> Split(byte[] secret, int parts, int minimum);

        byte[] Join(IDictionary<int, byte[]> parts);
    }
}