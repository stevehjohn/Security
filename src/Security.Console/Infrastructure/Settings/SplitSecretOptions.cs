using CommandLine;

namespace Security.Console.Infrastructure.Settings;

[Verb("SplitSecret", HelpText = "Split a secret so that parts that when recombined will reveal the secret.")]
public class SplitSecretOptions
{
    [Option('s', "Secret", Required = true, HelpText = "Base 64 encoded bytes containing the secret.")]
    public string Secret { get; set; }

    [Option('p', "Parts", Required = true, HelpText = "Number of parts to split the secret in to.")]
    public int Parts { get; set; }

    [Option('m', "Minimum", Required = true, HelpText = "Minimum number of parts required to reassemble the secret.")]
    public int Minimum { get; set; }
}