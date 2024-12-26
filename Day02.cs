// Advent of Code 2022, Day02
// https://adventofcode.com/2022/day/2
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	public class InputDataDay02 : InputDataDayXX
	{
		// Cast the data to the required type.	
		// Constructor
		List<Int32> _data = new List<Int32>();
		List<Int32> _data2 = new List<Int32>();
		public InputDataDay02(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			int j = 0;
		//	_data.Add(j);
			int score = 0;
			// Cast to required type
			while (i < _rawdata.Count())
				{
					if (_rawdata[i].ToString().Count() > 2)
						{
							if (_rawdata[i][2] == "X"[0])
							{
								score = 0;
								if (_rawdata[i][0] == "A"[0])
								{
									score += 3;
								};
								if (_rawdata[i][0] == "B"[0])
								{
									score += 1;
								};
								if (_rawdata[i][0] == "C"[0])
								{
									score += 2;
								};
							};
							if (_rawdata[i][2] == "Y"[0])
							{
								score = 3;
								if (_rawdata[i][0] == "A"[0])
								{
									score += 1;
								};
								if (_rawdata[i][0] == "B"[0])
								{
									score += 2;
								};
								if (_rawdata[i][0] == "C"[0])
								{
									score += 3;
								};
							};
							if (_rawdata[i][2] == "Z"[0])
							{
								score = 6;
								if (_rawdata[i][0] == "A"[0])
								{
									score += 2;
								};
								if (_rawdata[i][0] == "B"[0])
								{
									score += 3;
								};
								if (_rawdata[i][0] == "C"[0])
								{
									score += 1;
								};
							};

						_data.Add(score);
						}
					j = j + 1;
					i = i + 1;
				}
				for (int idx = 0; idx < _data.Count; idx++)
					{
						logger.LogInformation(_data[idx].ToString());
					}
		}
		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
				// return solution to part 1 here
				//throw new NotImplementedException("Solution to Part 1 is not implemented.");
				return _data.Sum();
			}
		}
		public override int SolutionToPart2
		{
			get
			{
				// return solution to part 2 here
				return _data.Sum();;
			}
	
		}
	}
}
