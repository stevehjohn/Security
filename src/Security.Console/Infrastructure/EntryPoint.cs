using CommandLine;
using Security.Console.Infrastructure.Settings;
using Security.Random;
using Security.Secrets;
using System;
using System.Linq;
using System.Text;
using Security.Crypto;

namespace Security.Console.Infrastructure
{
    public static class EntryPoint
    {
        public static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<GenerateKeyOptions, SplitSecretOptions, CombineOptions, ToBase64Options, FromBase64Options, EncryptOptions>(args)
                         .MapResult(
                             (GenerateKeyOptions options) => GenerateKey(options),
                             (SplitSecretOptions options) => SplitSecret(options),
                             (CombineOptions options) => Combine(options),
                             (ToBase64Options options) => ToBase64(options),
                             (FromBase64Options options) => FromBase64(options),
                             (EncryptOptions options) => Encrypt(options),
                             _ => 1);
        }

        private static int Encrypt(EncryptOptions options)
        {
            var key = Convert.FromBase64String(options.Key);

            var iv = Convert.FromBase64String(options.Iv);

            var salt = Convert.FromBase64String(options.Salt);

            var data = Convert.FromBase64String(options.Data);

            var cipher = new SymmetricCipher();

            var encrypted = cipher.Encrypt(data, key, iv, salt);
            
            Output($"\n  Encrypted data: {Convert.ToBase64String(encrypted)}");

            return 0;
        }

        private static int GenerateKey(GenerateKeyOptions options)
        {
            if (options.Length % 8 != 0)
            {
                Error("Length must be a multiple of 8.");
                return 0;
            }

            var bytes = new byte[options.Length / 8];

            var rng = new Rng();

            rng.GetBytes(bytes);

            Output($"\n  Key: {Convert.ToBase64String(bytes)}");

            return 0;
        }

        private static int SplitSecret(SplitSecretOptions options)
        {
            if (options.Parts < 2 || options.Parts > 16)
            {
                Error("Parts must be between 2 and 16.");
                return 0;
            }

            if (options.Minimum < 2)
            {
                Error("Minimum number of parts must not be less than 2.");
                return 0;
            }

            if (options.Minimum > options.Parts)
            {
                Error("Minimum number of parts must not exceed part count.");
                return 0;
            }

            byte[] data;

            try
            {
                data = Convert.FromBase64String(options.Secret);
            }
            catch
            {
                Error("Unable to decode base 64 secret.");
                return 0;
            }

            var splitter = new ShamirSecretShare(new Gf256(new Rng()), new Rng());

            var parts = splitter.Split(data, options.Parts, options.Minimum).ToArray();

            Output(string.Empty);

            for (var i = 0; i < parts.Length; i++)
            {
                Output($"  {i + 1, 2}: {Convert.ToBase64String(parts[i])}");
            }

            Output($"\n  Any {options.Minimum} of these can be combined to obtain the original secret.");

            return 0;
        }

        private static int Combine(CombineOptions options)
        {
            if (options.Parts < 2 || options.Parts > 16)
            {
                Error("Parts must be between 2 and 16.");
                return 0;
            }

            var parts = new byte[options.Parts][];

            Output(string.Empty);

            for (var i = 0; i < options.Parts; i++)
            {
                Output($"  Please enter part {i + 1}");

                var x = System.Console.CursorLeft;
                var y = System.Console.CursorTop;

                var part = Input("  > ");

                System.Console.CursorLeft = x;
                System.Console.CursorTop = y;

                Output($"  > {new string('*', part.Length)}");

                try
                {
                    parts[i] = Convert.FromBase64String(part);
                }
                catch
                {
                    Error("Unable to base 64 decode part.");
                    return 0;
                }
            }

            var joiner = new ShamirSecretShare(new Gf256(new Rng()), new Rng());

            var secret = joiner.Join(parts);

            Output($"\n  Secret: {Convert.ToBase64String(secret)}");

            return 0;
        }

        private static int ToBase64(ToBase64Options options)
        {
            if (string.IsNullOrWhiteSpace(options.Text))
            {
                Error("String is empty.");
                return 0;
            }

            Output($"\n  Original text: {options.Text}");
            Output($"\n  Base 64: {Convert.ToBase64String(Encoding.Unicode.GetBytes(options.Text))}");

            return 0;
        }

        private static int FromBase64(FromBase64Options options)
        {
            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(options.Data);
            }
            catch
            {
                Error("Unable to decode base 64 data");
                return 0;
            }

            Output($"\n Original text: {Encoding.Unicode.GetString(bytes)}");

            return 0;
        }

        private static void Error(string message)
        {
            System.Console.WriteLine($"ERROR:\n  {message}");
        }

        private static void Output(string message)
        {
            System.Console.WriteLine(message);
        }

        private static string Input(string prompt)
        {
            System.Console.Write(prompt);

            return System.Console.ReadLine();
        }
    }
}
