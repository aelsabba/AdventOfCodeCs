// Advent of Code 2022, Day 00
// https://adventofcode.com/2021/day/1
// @author: aharihar 

using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aoc2022.Logging;

namespace Aoc2022
{
	public class InputDataDay00 : InputDataDayXX
	{
		Int32[] _data;

		// Constructor
		public InputDataDay00(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			_rawdata.Remove(""); //remove empty strings
			// Cast to required type
			_data = new Int32[_rawdata.Count];
			for (int idx = 0; idx < _rawdata.Count; idx++)
			{
				_data[idx] = Int32.Parse(_rawdata[idx].Trim());
			}
            logger.LogDebug(String.Join(",", _data));
		}
		
		// Helper Methods
		// For part 1
		static bool depthIncreases(int num1, int num2)
		{
			return (num2 > num1)? true : false;
		}

		protected int SolvePart1()
		{
			int i;
			int count = 0;
			for (i=0; i<this._data.Length-1; i++)
			{
				if  (depthIncreases(this._data[i], this._data[i+1]))
				{
					count += 1;
				}
   				Thread.Sleep(1); 
			}
			return count;
		}


		// For part 2
		static bool depthIncreases(int[] arr1, int[] arr2)
		{
			return depthIncreases(arr1.Sum(), arr2.Sum());

		}
		
		protected int SolvePart2()
		{
			int i;
			int count = 0;
			const int blocksize = 3;
			int[] arr1 = new int[blocksize];
			int[] arr2 = new int[blocksize];
			for (i = 0; i < this._data.Length - 3; i++)
			{
				Array.Copy(this._data, i, arr1, 0, blocksize);
				Array.Copy(this._data, i+1, arr2, 0, blocksize);
				if (depthIncreases(arr1, arr2))
				{
					count += 1;
				}
				Thread.Sleep(1); 
			}
			return count;
		}


		// Properties
		public override int SolutionToPart1
		{
			get
			{
                logger.LogInformation("Solving Part 1");
				// return solution to part 1 here
				return SolvePart1();
			}
		}
		public override int SolutionToPart2
		{
			get
			{
                logger.LogInformation("Solving Part 2");
				// return solution to part 2 here
				return SolvePart2();
			}
	
		}
	}
}
