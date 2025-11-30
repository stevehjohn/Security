// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;
using JetBrains.Annotations;

namespace Security.Console.Infrastructure.Settings;

[UsedImplicitly]
[Verb("Combine", HelpText = "Combine parts of a secret to obtain the original data.")]
public class CombineOptions
{
    [Option('p', "Parts", Required = true, HelpText = "The minimum number of parts required to obtain the secret.")]
    public int Parts { get; set; }
}