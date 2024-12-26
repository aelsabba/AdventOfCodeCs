namespace Aoc2022
{
	public class AocInputDataFactory
	{
		public static IInputData ReadInputData(AocDay day, InputDataType dataType)
		{
			// returns the InputData object according to the day and dataType specified.
			IInputData input;
			switch (day)
			{
				case  ( AocDay.Day00 ):
					input = new InputDataDay00(dataType);
					break;	
				case  ( AocDay.Day01 ):
					input = new InputDataDay01(dataType);
					break;
				case  ( AocDay.Day02 ):
					input = new InputDataDay02(dataType);
					break;
				case  ( AocDay.Day03 ):
					input = new InputDataDay03(dataType);
					break;
				case  ( AocDay.Day04 ):
					input = new InputDataDay04(dataType);
					break;
				case  ( AocDay.Day05 ):
					input = new InputDataDay05(dataType);
					break;
				case  ( AocDay.Day06 ):
					input = new InputDataDay06(dataType);
					break;
				case  ( AocDay.Day07 ):
					input = new InputDataDay07(dataType);
					break;
				case  ( AocDay.Day08 ):
					input = new InputDataDay08(dataType);
					break;
				case  ( AocDay.Day09 ):
					input = new InputDataDay09(dataType);
					break;
				case  ( AocDay.Day10 ):
					input = new InputDataDay10(dataType);
					break;
				case  ( AocDay.Day11 ):
					input = new InputDataDay11(dataType);
					break;
				case  ( AocDay.Day12 ):
					input = new InputDataDay12(dataType);
					break;
				case  ( AocDay.Day13 ):
					input = new InputDataDay13(dataType);
					break;
				case  ( AocDay.Day14 ):
					input = new InputDataDay14(dataType);
					break;
				case  ( AocDay.Day15 ):
					input = new InputDataDay15(dataType);
					break;
				case  ( AocDay.Day16 ):
					input = new InputDataDay16(dataType);
					break;
				case  ( AocDay.Day17 ):
					input = new InputDataDay17(dataType);
					break;
				case  ( AocDay.Day18 ):
					input = new InputDataDay18(dataType);
					break;
				case  ( AocDay.Day19 ):
					input = new InputDataDay19(dataType);
					break;
				case  ( AocDay.Day20 ):
					input = new InputDataDay20(dataType);
					break;
				case  ( AocDay.Day21 ):
					input = new InputDataDay21(dataType);
					break;
				case  ( AocDay.Day22 ):
					input = new InputDataDay22(dataType);
					break;
				case  ( AocDay.Day23 ):
					input = new InputDataDay23(dataType);
					break;
				case  ( AocDay.Day24 ):
					input = new InputDataDay24(dataType);
					break;
				case  ( AocDay.Day25 ):
					input = new InputDataDay25(dataType);
					break;
				default:
					throw new NotImplementedException("Code for the day has not been implemented.");
			}
			return input;
		}
	}
}
