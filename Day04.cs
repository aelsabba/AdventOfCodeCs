// Advent of Code 2022, Day04
// https://adventofcode.com/2022/day/4
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
		public class Task
	{
		public List<Int32> _firstworker = new List<Int32>();
		public List<Int32> _secondworker = new List<Int32>();

		public List<Int32> getAssignment(String _range)
		{
			int _lower = Int32.Parse(_range.Split("-")[0]);
			int _upper = Int32.Parse(_range.Split("-")[1]);
			List<Int32> _worker = new List<Int32>();
			for (int x = _lower; x <= _upper; x++)
			{
				_worker.Add(x);
			}
			return _worker;
		}
		public Task(string fh,string sh)
		{
			_firstworker = getAssignment(fh);
			_secondworker = getAssignment(sh);
		}

	};
	public class InputDataDay04 : InputDataDayXX
	{
		// Cast the data to the required type.	
		// Constructor
		public List<Task> _workers = new List<Task>();
		public InputDataDay04(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			// Cast to required type
			while (i < _rawdata.Count())
				{
					if ((String.IsNullOrWhiteSpace(_rawdata[i].ToString())))
					{
						i = i + 1;
					}
					if (i < _rawdata.Count())
					{
					_workers.Add(new Task(_rawdata[i].Split(",")[0].Trim(),_rawdata[i].Split(",")[1].Trim()));
					}
					i = i + 1;
				}

		}
		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
			int i = 0;
			int j = 0;
			int _length = _workers.Count();
			// Cast to required type
			while (i < _length)
				{
					if (_workers[i]._firstworker.Count() > _workers[i]._secondworker.Count())
					{
						List<Int32> _temp = new List<Int32>(_workers[i]._secondworker);
						for (int x = 0; x < _workers[i]._firstworker.Count(); x++)
						{
							int _val = _workers[i]._secondworker.IndexOf(_workers[i]._firstworker[x]);
							if (_val >= 0)
							{
								_workers[i]._secondworker.Remove(_workers[i]._secondworker[_val]);
							}
							if (_workers[i]._secondworker.Count == 0)
							{
								j = j + 1;
								x = _workers[i]._firstworker.Count();
							}
						}
						_workers[i]._secondworker = _temp;
					}
					else
					{
						for (int x = 0; x < _workers[i]._secondworker.Count(); x++)
						{
							List<Int32> _temp = new List<Int32>(_workers[i]._firstworker);
							int _val = _workers[i]._firstworker.IndexOf(_workers[i]._secondworker[x]);
							if (_val >= 0)
							{
								_workers[i]._firstworker.Remove(_workers[i]._firstworker[_val]);
							}
							if (_workers[i]._firstworker.Count == 0)
							{
								j = j + 1;
								x = _workers[i]._secondworker.Count();
							}
							_workers[i]._firstworker = _temp;
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
			int _length = _workers.Count();
			// Cast to required type
			while (i < _length)
				{
					if (_workers[i]._firstworker.Count() > _workers[i]._secondworker.Count())
					{
						for (int x = 0; x < _workers[i]._firstworker.Count(); x++)
						{
							int _val = _workers[i]._secondworker.IndexOf(_workers[i]._firstworker[x]);
							if (_val >= 0)
							{
								j = j + 1;
								x = _workers[i]._firstworker.Count();
							}
						}
					}
					else
					{
						for (int x = 0; x < _workers[i]._secondworker.Count(); x++)
						{
							int _val = _workers[i]._firstworker.IndexOf(_workers[i]._secondworker[x]);
							if (_val >= 0)
							{
								j = j + 1;
								x = _workers[i]._secondworker.Count();
							}
						}
					}
				i = i + 1;
				}
			return j;
			}
	
		}
	}
}
