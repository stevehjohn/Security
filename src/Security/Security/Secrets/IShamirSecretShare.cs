using System.Collections.Generic;

namespace Security.Secrets
{
    public interface IShamirSecretShare
    {
        IEnumerable<byte[]> Split(byte[] secret, int parts, int minimum);

        IEnumerable<string> Split(string secret, int parts, int minimum, ByteEncoding encoding = ByteEncoding.Base64);
    }
}