using CommandLine;

namespace Security.Console.Infrastructure.Settings;

[Verb("GenerateKey", HelpText = "Generate a key for cryptographic operations.")]
public class GenerateKeyOptions
{
    [Option('l', "Length", Required = true, HelpText = "The length in bits of the key to generate.")]
    public int Length { get; set; }
}