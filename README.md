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

1. [.Net core](https://www.microsoft.com/net/core)

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


## Running the tests

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

## Authors

* **Reeve Lau** [email](mailto:reevelau@gmail.com)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

