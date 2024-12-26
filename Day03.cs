// Advent of Code 2022, Day03
// https://adventofcode.com/2022/day/3
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	public class _item
	{
		public String firsthalf;
		public String secondhalf;
		public String fulldata;

		public _item(string fh,string sh,string fd)
		{
			firsthalf = fh;
			secondhalf = sh;
			fulldata = fd;
		}

	};

	

	public class InputDataDay03 : InputDataDayXX
	{
		// Cast the data to the required type.	
		// Constructor
		List<_item> _data = new List<_item>();
		public InputDataDay03(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			// Cast to required type
			int i = 0;
			int j = 0;
			int _length = 0;
			// Cast to required type
			while (i < _rawdata.Count())
				{
					if (!(String.IsNullOrWhiteSpace(_rawdata[i].ToString())))
					{
						String _str = _rawdata[i].ToString();
						_length = _str.Length - 2;
						_data.Add(new _item(_str.Substring(0,(_str.Length / 2)),_str.Substring(_str.Length / 2,_str.Length - _str.Length / 2),_str));
					}
				i = i + 1;
				}
		}
		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
			int _total = 0;
				for (int idx = 0; idx < _data.Count; idx++)
					{
						int _length = _data[idx].firsthalf.Length;
						int _val = -1;
						int _val2 = 0;
						for (int idx2 = 0; idx2 < _length; idx2++)
						{
							if (_val < 0)
							{
							_val = _data[idx].secondhalf.IndexOf(_data[idx].firsthalf[idx2]);
							if (_val >= 0)
							{
								if (_data[idx].secondhalf[_val] <= "Z"[0])
								{
									_val2 = _data[idx].secondhalf[_val] - "A"[0] + 27;
								}
								else
								{
									_val2 = _data[idx].secondhalf[_val] - "a"[0] + 1;
								}
								//logger.LogInformation("full: " + _rawdata[idx] + " first half: " + _data[idx].firsthalf + " second half " + _data[idx].secondhalf + " repeat letter is " + _data[idx].secondhalf[_val] + " with value " + _val2);
							}
							}
						}
					//logger.LogInformation(_val2.ToString());
					_total = _total + _val2;
					}
				return _total;
			}
		}
		public override int SolutionToPart2
		{
			get
			{
			int _total = 0;
				for (int idx = 0; idx < _data.Count - 2; idx = idx + 3)
					{
						int _length = _data[idx].fulldata.Length;
						int _val = -1;
						int _val2 = 0;
						for (int idx2 = 0; idx2 < _length; idx2++)
						{
							if (_val < 0)
							{
								_val = _data[idx + 1].fulldata.IndexOf(_data[idx].fulldata[idx2]);
								if (_val >= 0)
								{
									_val = _data[idx + 2].fulldata.IndexOf(_data[idx].fulldata[idx2]);
									{
										if (_val >= 0)
										{
											if (_data[idx + 2].fulldata[_val] <= "Z"[0])
											{
												_val2 = _data[idx + 2].fulldata[_val] - "A"[0] + 27;
											}
											else
											{
												_val2 = _data[idx + 2].fulldata[_val] - "a"[0] + 1;
											}
											//logger.LogInformation("full: " + _rawdata[idx] + " first half: " + _data[idx].firsthalf + " second half " + _data[idx].secondhalf + " repeat letter is " + _data[idx].secondhalf[_val] + " with value " + _val2);
										}
									}
								}
							}

						}
					//logger.LogInformation(_val2.ToString());
					_total = _total + _val2;
					}
				return _total;
			}
	
		}
	}
}
