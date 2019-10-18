using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

public static class Commands{
    public static RootCommand Inflate()
    {
        var root = new RootCommand()
        {
            Commands.Init()
        };

        return root;

    } 

    public static Command Init()
    {
        var command = new Command("init", "initialize the Formfile.");
        var fileOption = new Option("-file", "specify the file")
        {
            Argument = new Argument<FileInfo>(()=>new FileInfo("./stack.yaml")),
        };

        fileOption.AddAlias("-f");

        command.AddArgument(new Argument<bool>(defaultValue:()=>false));
        command.AddAlias("i");
        command.AddOption(fileOption);

        command.Handler = CommandHandler.Create(
        (string file) =>
        {
          ;
        });

        return command;
    }

    // public static Option[] MainOptions()
    // {
    //     return { new Option(
    //         "--int-option",
    //         "An option whose argument is parsed as an int")
    //     {
    //         Argument = new Argument<int>(defaultValue: () => 42)
    //     },
    //     new Option(
    //         "--bool-option",
    //         "An option whose argument is parsed as a bool")
    //     {
    //         Argument = new Argument<bool>()
    //     },
    //     new Option(
    //         "--file-option",
    //         "An option whose argument is parsed as a FileInfo")
    //     {
    //         Argument = new Argument<FileInfo>()
    //     }
    // };
}