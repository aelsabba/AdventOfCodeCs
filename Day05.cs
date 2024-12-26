// Advent of Code 2022, Day05
// https://adventofcode.com/2022/day/5
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	public class InputDataDay05 : InputDataDayXX
	{
		// Cast the data to the required type.	
		// Constructor
		List<List<char>> _data = new List<List<char>>();
		public class Instruction
		{
			public int number;
			public int from;
			public int to;

			public Instruction(int fh,int sh,int fd)
			{
				number = fh;
				from = sh - 1;
				to = fd - 1;
			}

		};
		List<Instruction> _instructions = new List<Instruction>();
		public InputDataDay05(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			int firstrow = 0;
			// Cast to required type
			while (i < _rawdata.Count() & firstrow == 0)
				{
					if (!(_rawdata[i][0].ToString() == "["))
					{
						firstrow = i;
					}
					i = i + 1;
				}
			i = 0;
			int j = 1;
			int instructionsrow = firstrow + 2;
			String firstrowdata = _rawdata[firstrow].Replace(" ","").Replace("[","").Replace("]","").Replace("\r","");
		 	int frstrowlength = Int32.Parse(firstrowdata[firstrowdata.Length - 1].ToString());
			firstrow = firstrow - 1;
			firstrowdata = _rawdata[firstrow]; //.Replace(" ","").Replace("[","").Replace("]","").Replace("\r","");
			while (i <= firstrow)
			{
				while ( ((j - 1.0) / 4.0) < frstrowlength)
				{
					if (i == 0)
					{
						_data.Add(new List<char> {firstrowdata[j]});
					}
					else if (!(String.IsNullOrWhiteSpace(firstrowdata[j].ToString())))
					{
						_data[((j - 1) / 4)].Add(firstrowdata[j]);
					}
					j = j + 4;
				}
				j = 1;
				i = i + 1;
				if (firstrow - i >= 0)
				{
					firstrowdata = _rawdata[firstrow - i];
				} //.Replace(" ","").Replace("[","").Replace("]","").Replace("\r","");}
			}
			while (instructionsrow < _rawdata.Count())
			{
				_rawdata[instructionsrow] = _rawdata[instructionsrow].Replace("move ","").Replace("from ","").Replace("to ","").Replace("\r","");
				_instructions.Add(new Instruction(Int32.Parse(_rawdata[instructionsrow].Split(" ")[0]),Int32.Parse(_rawdata[instructionsrow].Split(" ")[1]),Int32.Parse(_rawdata[instructionsrow].Split(" ")[2])));
				instructionsrow = instructionsrow + 1;
			}
		}

		

		// Properties
		public override int SolutionToPart1
		{
			get
			{
				List<List<char>> _databackup = new List<List<char>>();
				int i = 0;
				while (i < _data.Count)
				{
					_databackup.Add(new List<char>(_data[i]));
					i = i + 1;
				}
				i = 0;
				int j = 0;
				while (i < _instructions.Count())
				{
					while (j < _instructions[i].number)
					{
						_data[_instructions[i].to].Add(_data[_instructions[i].from][_data[_instructions[i].from].Count - 1]);
						_data[_instructions[i].from].RemoveAt(_data[_instructions[i].from].Count - 1);
						j = j + 1;
					}
					j = 0;
					i = i + 1;
				}
				i = 0;
				string output = new string("");
				while (i < _data.Count)
				{
					output = output + _data[i][_data[i].Count - 1];
					i = i + 1;
				}
				logger.LogInformation(output);
				_data = _databackup;
				return 1;
			}
		}
		public override int SolutionToPart2
		{
			get
			{
				int i = 0;
				int j = 0;
				while (i < _instructions.Count())
				{
					if (_instructions[i].number == 1)
					{
						_data[_instructions[i].to].Add(_data[_instructions[i].from][_data[_instructions[i].from].Count - 1]);
						_data[_instructions[i].from].RemoveAt(_data[_instructions[i].from].Count - 1);						
					}
					else
					{
						while (j < _instructions[i].number)
							{
								_data[_instructions[i].to].Add(_data[_instructions[i].from][_data[_instructions[i].from].Count - _instructions[i].number + j]);
								_data[_instructions[i].from].RemoveAt(_data[_instructions[i].from].Count - _instructions[i].number + j);
								j = j + 1;
							}
					}
					j = 0;
					i = i + 1;
				}
				i = 0;
				string output = new string("");
				while (i < _data.Count)
				{
					output = output + _data[i][_data[i].Count - 1];
					i = i + 1;
				}
				logger.LogInformation(output);
				return 1;
			}
	
		}
	}
}
