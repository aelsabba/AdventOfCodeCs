// Advent of Code 2022, Day01
// https://adventofcode.com/2022/day/1
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	public class InputDataDay01 : InputDataDayXX
	{

		// Cast the data to the required type.	

		List<Int32> _data = new List<Int32>();
		// Constructor
		public InputDataDay01(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			int j = 0;
			_data.Add(j);
			// Cast to required type
			while (i < _rawdata.Count())
				{
					if ((String.IsNullOrWhiteSpace(_rawdata[i].ToString())))
					{
						i = i + 1;
						j = j + 1;
						_data.Add(j);
						_data[j] = 0;
					}
					if (i < _rawdata.Count())
					{
					_data[j] = _data[j] + Int32.Parse((_rawdata[i].ToString()));
					}
					i = i + 1;
				}
		//	for (int idx = 0; idx < _data.Count; idx++)
		//		{
		//			logger.LogInformation(_data[idx].ToString());
		//		}
		}
		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
				int max = 0;
				int maxidx = 0;
				for (int idx = 0; idx < _data.Count; idx++)
					{
						if (_data[idx] > max)
						{
							max = _data[idx];
							maxidx = idx;
						}
					}
				//logger.LogInformation(maxidx.ToString());
				return max;
				// return solution to part 1 here
			}
		}
		public override int SolutionToPart2
		{
			get
			{
				int max3 = 0;
				int max2 = 0;
				int max = 0;
				int maxidx = 0;
				for (int idx = 0; idx < _data.Count; idx++)
					{
						if (_data[idx] > max)
						{
							max3 = max2;
							max2 = max;
							max = _data[idx];
							maxidx = idx;
						}
						else if (_data[idx] > max2)
						{
							max2 = _data[idx];
						}
						else if (_data[idx] > max3)
						{
							max3 = _data[idx];
						}
					//logger.LogInformation(_data[idx].ToString());

					}
				//logger.LogInformation(maxidx.ToString());
				logger.LogInformation(max3.ToString());
				logger.LogInformation(max2.ToString());
				logger.LogInformation(max.ToString());
				return max + max2 + max3;
			}
	
		}
	}
}
