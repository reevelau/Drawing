# Drawing Program

This is a simple command line drawing program. The program is intended to work as follows:
 1. Create a new canvas
 2. Start drawing on the canvas by issuing various commands
 3. Quit

````
Command         Description
C w h           Should create a new canvas of width w and height h.
L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported. 
                Horizontal and vertical lines will be drawn using the 'x' character.
R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2). Horizontal and vertical lines will be drawn
                using the 'x' character.
B x y c         Should fill the entire area connected to (x,y) with "colour" c. The
                behaviour of this is the same as that of the "bucket fill" tool in paint
                programs.
Q               Should quit the program.
````

## Getting Started

This is dotnet core project. To be honest, this is the first time I explore the possiblility of dotnet core with Visual Studio Code. The experience isn't as good as on the Visual Studio + Resharper. But it is still very fun. To compile and run this project, you need the followings.

### Prerequisites

1. [.Net core](https://www.microsoft.com/net/core) (1.0.4+)

### Optional

1. [Visual Studio Code](https://code.visualstudio.com/) (for viewing and editing)
2. [Visual Studio Code C# Support](https://code.visualstudio.com/docs/languages/csharp)

### Installing Dependencies

After you get dotnet core installed on your computer. Go to the directory that contains "Drawing.sln" and open terminal app and cd to the path.

Then you can restore the depending libraies by this command

````
dotnet restore
````
The result should look like the following
````
  Restoring packages for /Users/reeve/dotnet/Drawing/Drawing.Engine/Drawing.Engine.csproj...
  Restoring packages for /Users/reeve/dotnet/Drawing/Drawing.Engine.Test/Drawing.Engine.Test.csproj...
  Restoring packages for /Users/reeve/dotnet/Drawing/Drawing.CLI/Drawing.CLI.csproj...
....
  NuGet Config files used:
      /Users/reeve/.nuget/NuGet/NuGet.Config
  
  Feeds used:
      https://api.nuget.org/v3/index.json
````

## Runnig the program

Once after you installed the dependencies, you can run the program by this command.

````
dotnet run -p Drawing.CLI/Drawing.CLI.csproj 
````

## Running the test

This project is convered by a Unit test project. You can run the tests by this command.

````
dotnet test Drawing.Engine.Test/Drawing.Engine.Test.csproj
````
The result is
````
Build started, please wait...
Build completed.

Test run for /Users/reeve/dotnet/Drawing/Drawing.Engine.Test/bin/Debug/netcoreapp1.1/Drawing.Engine.Test.dll(.NETCoreApp,Version=v1.1)
Microsoft (R) Test Execution Command Line Tool Version 15.0.0.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:01.0011736]   Discovering: Drawing.Engine.Test
[xUnit.net 00:00:01.2448953]   Discovered:  Drawing.Engine.Test
[xUnit.net 00:00:01.3507989]   Starting:    Drawing.Engine.Test
[xUnit.net 00:00:01.9792238]   Finished:    Drawing.Engine.Test

Total tests: 44. Passed: 44. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 2.8221 Seconds
````

## About the code

The .Net core solution contains 3 projects and the structure look like this.

````
Drawing/
├── Drawing.CLI
├── Drawing.Engine
├── Drawing.Engine.Test
├── Drawing.sln
└── README.md
````

### Drawing.CLI
It is a thin wrapper for logic in `Drawing.Engine` project.

### Drawin.Engine
It is the main library of this solution. It contains all the logic that run the program. The project has the following structure:

````
Drawing.Engine
├── Command
├── Drawing.Engine.csproj
├── Geometry
├── Invoker
├── Receiver
└── Text
````
The program is built on [Command Pattern](https://en.wikipedia.org/wiki/Command_pattern). All new command should add to `Command` folder. The logic that do coordinate calculation should go to `Geometry`. While the logic related to canvas are stored in `Receiver`. The `Invoker` folder has logic to control how the command is executed. Since this is a console application, we have a `Text` folder to store logic to present and process text content.

### Drawing.Engine.Test
It is the test project. It is configured to use [xunit](https://github.com/xunit/xunit) and [moq](https://github.com/moq/moq) to provide assertion checking and interface mocking.


## Authors

* **Reeve Lau** [email](mailto:reevelau@gmail.com)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Afterthought

1. .Net core is pure console base framework. It is great to be used for server-base application.
2. .Net core + Visual Studio Code is ok to use. 
    - Vscode provides `intellisense` which is good. But sometimes the behavior mixes up with the keyword suggestion that used in script base language, making the suggestion a bit confusing.
    - [#1292](https://github.com/OmniSharp/omnisharp-vscode/issues/1292) makes me unable to debug `xunit` tests.  
3. `xunit` and `moq` can be used faultlessly which is a plus sign.