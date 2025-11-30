using CommandLine;

namespace Security.Console.Infrastructure.Settings;

[Verb("FromBase64", HelpText = "Convert base 64 data into text.")]
public class FromBase64Options
{
    [Option('d', "Data", Required = true, HelpText = "Base 64 encoded text.")]
    public string Data { get; set; }
}