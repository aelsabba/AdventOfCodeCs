using System.IO;
using System.Collections.Generic;
using Aoc2022.Logging;

namespace Aoc2022
{
	public abstract class InputDataDayXX : IInputData
	{
		string _filename;
		InputDataType _dataType;
		protected List<string> _rawdata;
        protected Logger logger = Logger.Instance;

		// Constructor
		public InputDataDayXX(InputDataType dataType, string seperator = "\n", string id = "")
		{
			// Data is stored in ./Data/DayXX/Data.txt or ./Data/DayXX/Sample.txt
			// For instances where there are more than one samples - Sample1.txt, Sample2.txt etc
			_dataType = dataType;
			_filename = $"./Data/{this.GetType().Name.Substring(9,5)}/{dataType.ToString()}{id}.txt";
            logger.LogInformation($"Reading from {_filename}");
			if (File.Exists(_filename))
			{
				_rawdata = File.ReadAllText(_filename).Split(seperator).ToList();	
				Console.WriteLine($"{_rawdata.Count} lines read");	
			}
			else
			{
				throw new FileNotFoundException($"{_filename} was not found. Please copy the data file correctly.")	;
			}
		}

		// Methods
		public void PrintRawDataToConsole()
		{
			foreach (string _raw in _rawdata)
			{
				Console.WriteLine(_raw);
			}
		}


		// Properties
		public List<string> RawData
		{
			get => this._rawdata;
		}


		public virtual int  SolutionToPart1
		{
			get
			{
				// return solution to part 1 here
				throw new NotImplementedException("Solution to Part 1 is not implemented.");
			}
		}
		public virtual int SolutionToPart2
		{
			get
			{
				// return solution to part 2 here
				throw new NotImplementedException("Solution to Part 2 is not implemented.");
			}
	
		}
	}
}
