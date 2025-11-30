using System;

namespace Security.Extensions;

public static class ByteArrayExtensions
{
    extension(byte[] bytes)
    {
        public string ToBase64()
        {
            return Convert.ToBase64String(bytes);
        }

        public string ToHex()
        {
            return Convert.ToHexString(bytes);
        }
    }
}