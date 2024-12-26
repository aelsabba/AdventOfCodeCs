// Advent of Code 2022, Day06
// https://adventofcode.com/2022/day/6
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	public class InputDataDay06 : InputDataDayXX
	{
		// Cast the data to the required type.	
		// Constructor
		List<char> _data = new List<char>();
		public InputDataDay06(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			while (i < _rawdata[0].Length)
			{
				_data.Add(_rawdata[0][i]);
				i = i + 1;
			}
		}
		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
				List<char> _temp =new List<char>();
				_temp.Add(","[0]);
				_temp.Add(","[0]);
				_temp.Add(","[0]);
				_temp.Add(","[0]);
				int i = 0;
				int j = 0;
				while (i < _data.Count())
				{
					_temp[0] = ","[0];
					_temp[1] = ","[0];	
					_temp[2] = ","[0];
					_temp[3] = ","[0];				
					_temp[0] = _data[i];
					if (_temp.IndexOf(_data[i + 1]) == -1)
					{
						_temp[1] = _data[i + 1];
						if (_temp.IndexOf(_data[i + 2]) == -1)
						{
							_temp[2] = _data[i + 2];
							if (_temp.IndexOf(_data[i + 3]) == -1)
							{
								_temp[3] = _data[i + 3];
								j = i + 3 + 1;
								i = _data.Count();
							}
						}
					}
					i = i + 1;

				}
				return j;
			}
		}
		public override int SolutionToPart2
		{
			get
			{
				int i = 0;
				int j = 0;
				int k = 0;
				while (i < _data.Count())
				{
					List<char> _temp = new List<char>();
					while (j < 14)
					{
						if (_temp.IndexOf(_data[i + j]) == -1)
						{
							_temp.Add(_data[i + j]);
							j = j + 1;
							if (j == 14)
							{
								k = i + 14;
								i = _data.Count();
							}
						}
						else
						{
							j = 14;
						}
					}
					j = 0;
					i = i + 1;
				}
			return k;
			}
	
		}
	}
}
