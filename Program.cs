using Aoc2022;
using System.Diagnostics;
using Aoc2022.Logging;

class Program
{

	static void Main(string[] args)
	{
		AocDay day;
				
		if ((args.Length == 1) && (Enum.TryParse(args[0], out day)))
		{
			// Setup the Logger
			Logger.Category = day.ToString();
			Logger.Level = LogLevel.INFO; // Change the Logging Level here
			Logger logger = Logger.Instance;

			logger.LogInformation($"Starting Execution of {day.ToString()}");

			try
			{
				var sampleData = AocInputDataFactory.ReadInputData(day, InputDataType.Sample);
				var actualData = AocInputDataFactory.ReadInputData(day, InputDataType.Data);

				// Part 1
				Console.WriteLine("\n~~~** Part 1 **~~~");
				(int result, Int64 timeElapsed) solution = Solve(sampleData, AocPart.Part1);
				logger.LogInformation($"Solution to Part 1 - Sample - is {solution.result}  \n\t Time elapsed : {solution.timeElapsed}");
				solution = Solve(actualData, AocPart.Part1);
				logger.LogInformation($"Solution to Part 1 - Data - is {solution.result}  \n\t Time elapsed : {solution.timeElapsed}");

				// Part 2
				Console.WriteLine("\n~~~** Part 2 **~~~");
				solution = Solve(sampleData, AocPart.Part2);
				logger.LogInformation($"Solution to Part 2 - Sample - is {solution.result}  \n\t Time elapsed : {solution.timeElapsed}");
				solution = Solve(actualData, AocPart.Part2);
				logger.LogInformation($"Solution to Part 2 - Data - is {solution.result}  \n\t Time elapsed : {solution.timeElapsed}");

			}
			catch (NotImplementedException ex)
			{
				// Catch NotImplemented Exceptions - the program throws this when the solution is not implemented.
				// This is the only error we throw in the program.
				// All other errors are from doing something wrong.
				logger.LogError($"{ex.Message} \n\t {ex.StackTrace}");
			}
			finally
			{
				// Dispose Logger
				logger.Dispose();	
			}
		}
		else
		{
			throw new InvalidProgramException("Incorrect argument passed to Main function. Arguments must be one of - Day00, Day01... , Day25");
		}
	}

	static (int result, Int64 timeElapsed) Solve(IInputData data, AocPart part)
	{
		Int32 result;
		Int64 timeElapsed;
		Stopwatch sw = new Stopwatch();
		sw.Start();
		switch (part)
		{
			case (AocPart.Part1):
				result = data.SolutionToPart1;
				break;
			case (AocPart.Part2):
				result = data.SolutionToPart2;
				break;
			default:
				throw new ArgumentException("Invalid argument for AocPart.");
		}
		sw.Stop();
		timeElapsed = sw.ElapsedMilliseconds;

		return (result, timeElapsed);
	}

}
