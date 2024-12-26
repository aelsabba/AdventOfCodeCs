
# Advent of Code 2022 in C#

This repository is setup to help you attempt to solve the [Advent of Code 2022](https://adventofcode.com/2022) in C#. Advent of Code is a fun way to learn/master a new programming language.  It is useful if you are generally  familiar (at a beginner level/taken a college course in programming)  with a programming language and Object Oriented Programming and want to extend and refine your skills. It can be very challenging if this is your first attempt at programming.
In course of doing even just 10 out of these 25 puzzles - difficulty of which varies each day, but progressively gets more difficult - you will learn
1. How to manipulate strings, regex, etc
2. Type conversion
3. Collections - Structs, Lists, Dicts, Arrays etc
4. File IO
5. Classes, Objects, Methods, Properties, Composition, Inheritance, Polymorphism etc. - foundations of OOP.
6. Access Modifiers
7. Some appreciation of algorithms and computational complexity.
8. Learn to use VSCode - and the built in debugger. You will understand and manipulate its settings. Understand and debug compilation and build errors for .NET6.

Even just attempting the first 10 puzzles will give you a significant boost in your abilities. Kudos if you make it to 15. By 20, you would've explored concepts you have previously never encountered.

A new puzzle is launched at 0000 hr Eastern Time each day starting December 1st to December 25th.
Each day's puzzle consists of two parts - the second part usually extends the first in a specific way. You will learn how to anticipate changes that may be required in your code and how to write code that can easily adapt to changing requirements.
Each day has one puzzle input and at least one example associated with each part.

If you get stuck, feel free to browse someone else's code to learn how to implement a solution. Ideally you want to attempt a solution before you browse and then implement the solution again/differently. This reinforces the learning of new concepts - once when you attempted it and again when you implement the new solution after browsing someone else. This [subreddit](https://www.reddit.com/r/adventofcode/) can be useful for solutions.

## How to use this repo
This repo will do some of the heavy lifting for you and help you focus on enjoying writing code to solve the problem at hand. Some tasks however are still to be done manually.
### Setup
1. Windows or Linux Computer with a internet connection.
2. Install [.NET6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
3. Install [VSCode](https://code.visualstudio.com).
4. Install Git.
5. You could alternately use a simple text editor (instead of VSCode) and run the programs through the command-line - ie. Hardcore mode. But I wouldn't recommend it. Intellisense in VSCode is pretty neat and can usually help you write code better and faster. Debugging tools are excellent in VSCode for C#.
6. Clone the repo. You don't have to use this repo/framework to solve Advent of Code. Feel free to implement your own. This repo merely takes some of the routine steps of reading in the data and output a result and standardizes it.
8. Create a branch  for yourself - `git branch users/<username>`. And commit all your code to this branch. This way you can share code amongst others working on this and learn from each other. You could alternately fork the code to your own account - but we'd lose the benefit of having everyone's code in the same repo to learn from.
9. Run the example Day00 puzzle by downloading the Data from [Advent of Code 2021](https://adventofcode.com/2021/day/1). See debugging and running a solution below.

### Repo architecture
For the curious, this is what is happening under the hood.
* The code architecture is a console application called `aoc2022`.
* The heart of the repo is an Interface called `IInputData` - which implements the properties `RawData`, `SolutionToPart1` and `SolutionToPart2`.
* `Program.cs` contains the main entry-point code - `Main()` - which calls a factory function based on the command line argument passed.
* In its base state, when the interface is fully implemented - the application will print the solution to part 1 and part 2 - for both the sample and data.
* Data goes in the Data folder and DayXX subfolder.
* `.gitignore` is set to ignore the `Data`, `Logs`, `bin` and `obj` folders - these may be different for everyone - There is some randomization of the data - so not all of us will have the same data to work with.  
*

## Solving the puzzle
After the setup, for each day/puzzle, in order to solve the puzzle you need to
1. Read the puzzle carefully
2. Copy the sample data and input data to the `Data\DayZZ\Sample.txt` and `Data\DayZZ\Data.txt`
3. Edit the code in `DayZZ.cs`.  Each `DayZZ.cs` implements a [class](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes) that is based on in `IInputData` [interface](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces).  So you have to implement at least two [properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties) - `SolutionToPart1`, and `SolutionToPart2`.
4. You may create as many helper functions and classes for the data as you like. You will have to almost always cast the raw data to something more computationally useful.
5. Build the solution.
6. Run the program with the argument `DayZZ`. Feel free to comment out sections of `Program.cs` when you are testing out your code - code that is not implmented will raise a not implemented exception.

`DayZZ`  - generically refers to Day01, Day02 etc.
### Hints for solving
1. Read the puzzle carefully.
2. Test the code against the example data
3. Recursion is your friend. As are regular expressions (regex).
4. If the solution takes longer than a few minutes (say 15?) to run - there is usually a better way to implement it - ie. reduce time complexity. Take few minutes to read through the subreddit and figure out what you need to change in your implementation.
5. Pay attention to and read the runtime exceptions and build errors. There is usually enough information in there for you to start debugging.
6. Use the `logger` object in each class to log debug information. The `logger` logs to both the console and to a logfile in `.\Logs\DayZZ.log`. The log files are individualized for each day and are append only and persistent.
    - The default `LogLevel` is `INFO`. You may change this to `DEBUG` in `Program.cs`.
    - Experiment with this feature with  Day00  and see the changes in the log file.
    - `logger.LogDebug(string)` or `logger.LogInformation(string)` - will help you log.


### Running and Debugging a solution
- The repo ships with a default solution implemented in `Day00.cs`. This is the puzzle from [Day01 of 2021](https://adventofcode.com/2021/day/1). Run this to ensure you have all your tools properly installed. You will have to pull your own data for Day00 from Day01 of 2021.
#### In VSCode
- From the current working directory `...\aoc2022cs\`, the command `code .` open VSCode with the currently folder loaded.
- With the given day's  file `DayZZ.cs` open, you can Start Debugging  with F5. Alternately click the Run and Debug button on the sidebar, and  Start Debugging by running `Currently Open Day`. This will build the project and then execute the code from the entry point.
![image.png](./image_1669780478809_0.png)
- It is imperative that the file `DayZZ.cs` that you are running be open when you hit F5. That filename is used as an argument in to the Main entry point. See `.vscode\launch.json`.
- You can place breakpoints by clicking next to the line numbers in the code. See line 17 above. The space for variables, watches and the call stack is also seen the above screenshot. As is the console output.
- If you merely want to build the solution, you can go to Terminal->Run Task->Build.

#### On the command line
- In the folder containing the solution file, build the solution using `dotnet build`
When the build is successful, you will see an output like this
```
dotnet build
Microsoft (R) Build Engine version 17.0.1+b177f8fa7 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.
Determining projects to restore...
All projects are up-to-date for restore.
aoc2022cs -> /home/Aditya/Documents/Programming/CSharp/aoc/aoc2022cs/bin/Debug/net6.0/aoc2022cs.dll
Build succeeded.
0 Warning(s)
0 Error(s)
```
- Run the solution with the command `dotnet run -- DayZZ` - replace DayZZ with Day00, Day01 etc. You should see something like
```
dotnet run -- Day00
2022-11-29T21:48:43 : [INFO] : Reading from ./Data/Day00/Sample.txt
11 lines read
2022-11-29T21:48:43 : [INFO] : Reading from ./Data/Day00/Data.txt
2001 lines read

~ ~ ~ ** Part 1 **~ ~ ~
2022-11-29T21:48:43 : [INFO] : Solving Part 1
2022-11-29T21:48:43 : [INFO] : Solution to Part 1 - Sample - is 7  
	 Time elapsed : 9
2022-11-29T21:48:43 : [INFO] : Solving Part 1
2022-11-29T21:48:45 : [INFO] : Solution to Part 1 - Data - is 1266  
	 Time elapsed : 2159

~ ~ ~ ** Part 2 ** ~ ~ ~
2022-11-29T21:48:45 : [INFO] : Solving Part 2
2022-11-29T21:48:45 : [INFO] : Solution to Part 2 - Sample - is 5  
	 Time elapsed : 8
2022-11-29T21:48:45 : [INFO] : Solving Part 2
2022-11-29T21:48:47 : [INFO] : Solution to Part 2 - Data - is 1217  
	 Time elapsed : 2167
```

