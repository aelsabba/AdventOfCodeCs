namespace Aoc2022
{
	public interface IInputData
	{
		List<string> RawData {get;}
		int SolutionToPart1 {get;}
		int SolutionToPart2 {get;}
	}


	public enum InputDataType
	{
		Sample = 0,
		Data = 1
	}
	
	public enum AocDay
	{
		Day00,
		Day01,
		Day02,
		Day03,
		Day04,
		Day05,
		Day06,
		Day07,
		Day08,
		Day09,
		Day10,
		Day11,
		Day12,
		Day13,
		Day14,
		Day15,
		Day16,
		Day17,
		Day18,
		Day19,
		Day20,
		Day21,
		Day22,
		Day23,
		Day24,
		Day25,
	}

	public enum AocPart
	{
		Part1 = 1,
		Part2 = 2
	}
}
