using System.CommandLine;
using System;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

class Program
{ 
   static async Task<int> Main(string[] args)
{
    // Create a root command with some options
    var rootCommand = new RootCommand
    {
        Commands.InitCommand(),
        new Option(
            "--int-option",
            "An option whose argument is parsed as an int")
        {
            Argument = new Argument<int>(defaultValue: () => 42)
        },
        new Option(
            "--bool-option",
            "An option whose argument is parsed as a bool")
        {
            Argument = new Argument<bool>()
        },
        new Option(
            "--file",
            "A Stack or Deployment file")
        {
            Argument = new Argument<FileInfo>()
        }
    };

    rootCommand.Description = "My sample app";

    rootCommand.Handler = CommandHandler.Create<bool, int, bool, FileInfo>(async (init, intOption, boolOption, fileOption) =>
    {
        if (init)
        {
            Console.WriteLine($"Writing Geneisis Block ...");
            var result = await Init.Create(new string []{fileOption.FullName});
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        Console.WriteLine($"The value for --int-option is: {intOption}");
        Console.WriteLine($"The value for --bool-option is: {boolOption}");
        Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
    });

    // Parse the incoming args and invoke the handler
    return rootCommand.InvokeAsync(args).Result;
    }
}