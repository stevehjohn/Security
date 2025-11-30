using CommandLine;

namespace Security.Console.Infrastructure.Settings;

[Verb("ToBase16", HelpText = "Convert a string to base 16.")]
public class ToBase16Options
{
    [Option('t', "Text", Required = true, HelpText = "The text to convert to base 64, in double quotes if it contains spaces.")]
    public string Text { get; set; }
}