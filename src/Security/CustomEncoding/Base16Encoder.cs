using System.Text;

namespace Security.CustomEncoding
{
    public class Base16Encoder : IEncoder
    {
        private const string Alphabet = "ACDFGHJKMNRTUVWX";

        public string GetString(byte[] data)
        {
            var result = new StringBuilder();

            var rng = new System.Random();
            
            foreach (var b in data)
            {
                var c = Alphabet[(b & 0xcF0) >> 4];

                if (rng.Next(2) == 0)
                {
                    c = char.ToLower(c);
                }

                result.Append(c);

                c = Alphabet[b & 0x0F];

                if (rng.Next(2) == 0)
                {
                    c = char.ToLower(c);
                }
                
                result.Append(c);
            }

            return result.ToString();
        }

        public byte[] GetBytes(string data)
        {
            var result = new byte[data.Length / 2];

            var i = 0;

            foreach (var c in data)
            {
                var index = Alphabet.IndexOf(c);

                result[i / 2] |= i % 2 != 1
                                     ? (byte) (index << 4)
                                     : (byte) index;

                i++;
            }

            return result;
        }
    }
}