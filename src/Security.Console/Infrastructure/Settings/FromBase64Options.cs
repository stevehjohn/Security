// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;
using JetBrains.Annotations;

namespace Security.Console.Infrastructure.Settings;

[UsedImplicitly]
[Verb("FromBase64", HelpText = "Convert base 64 data into text.")]
public class FromBase64Options
{
    [Option('d', "Data", Required = true, HelpText = "Base 64 encoded text.")]
    public string Data { get; set; }
}