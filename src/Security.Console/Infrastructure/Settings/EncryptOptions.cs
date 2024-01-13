using CommandLine;

namespace Security.Console.Infrastructure.Settings;

[Verb("Encrypt", HelpText = "Encrypt some data.")]
public class EncryptOptions
{
    [Option('k', "Key", Required = true, HelpText = "Base 64 encoded key.")]
    public string Key { get; set; }

    [Option('i', "IV", Required = true, HelpText = "Base 64 encoded initialisation vector.")]
    public string Iv { get; set; }
    
    [Option('s', "Salt", Required = true, HelpText = "Base 64 encoded salt.")]
    public string Salt { get; set; }
    
    [Option('d', "Data", Required = true, HelpText = "Base 64 encoded data to be encrypted.")]
    public string Data { get; set; }
}