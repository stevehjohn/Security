// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;
using JetBrains.Annotations;

namespace Security.Console.Infrastructure.Settings;

[UsedImplicitly]
[Verb("GenerateKey", HelpText = "Generate a key for cryptographic operations.")]
public class GenerateKeyOptions
{
    [Option('l', "Length", Required = true, HelpText = "The length in bits of the key to generate.")]
    public int Length { get; set; }
}