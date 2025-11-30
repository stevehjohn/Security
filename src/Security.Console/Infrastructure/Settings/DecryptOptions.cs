// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;
using JetBrains.Annotations;

namespace Security.Console.Infrastructure.Settings;

[UsedImplicitly]
[Verb("Decrypt", HelpText = "Decrypt some data.")]
public class DecryptOptions
{
    [Option('k', "Key", Required = true, HelpText = "Base 64 encoded key.")]
    public string Key { get; set; }

    [Option('i', "IV", Required = true, HelpText = "Base 64 encoded initialisation vector.")]
    public string Iv { get; set; }
    
    [Option('s', "Salt", Required = true, HelpText = "Base 64 encoded salt.")]
    public string Salt { get; set; }
    
    [Option('d', "Data", Required = true, HelpText = "Base 64 encoded secret to be decrypted.")]
    public string Data { get; set; }
}