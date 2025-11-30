// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;
using JetBrains.Annotations;

namespace Security.Console.Infrastructure.Settings;

[UsedImplicitly]
[Verb("ToBase64", HelpText = "Convert a string to base 64.")]
public class ToBase64Options
{
    [Option('t', "Text", Required = true, HelpText = "The text to convert to base 64, in double quotes if it contains spaces.")]
    public string Text { get; set; }
}