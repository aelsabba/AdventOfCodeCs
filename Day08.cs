// Advent of Code 2022, Day08
// https://adventofcode.com/2022/day/8
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{
	
	public class line
	{
		public List<gridLocation> _data = new List<gridLocation>();
		public int maxleft;
		public int maxright;
	}

	public class gridLocation
	{
		public int x = new int();
		public int y = new int();
		public int dup;
		public int ddown;
		public int dleft;
		public int dright; 
		public int height = 0;
		public bool visible = false;
		public gridLocation(int X, int Y, int H)
		{
			x = X;
			y = Y;
			height = H;
		}
		public int getScore(line horizontal, line vertical, int a, int b)
		{
			int l = x;
			int m = y;
			dup = -1;
			ddown = -1;
			dleft = -1;
			dright = -1;
			a = y - 1;
			while (a >= 0)
			{
				if (a == 0)
				{
					dleft = y;
				}
				if (horizontal._data[a].height >= height & dleft < 0)
				{
					dleft  = y - a;
					a = -1;
				}
				a = a - 1;
			}
			a = y + 1;
			while (a < horizontal._data.Count())
			{
				if (a == horizontal._data.Count() - 1)
				{
					dright = horizontal._data.Count() - 1 - y;
				}
				if (horizontal._data[a].height >= height & dright < 0)
				{
					dright  = a - y;
					a = horizontal._data.Count() + 2;
				}
				a = a + 1;
			}
			////////////////////////
			b = x - 1;
			while (b >= 0)
			{
				if (b == 0)
				{
					dup = x;
				}
				if (vertical._data[b].height >= height & dup < 0)
				{
					dup  = x - b;
					b = -1;
				}
				b = b - 1;
			}
			b = x + 1;
			while (b < vertical._data.Count())
			{
				if (b == vertical._data.Count() - 1)
				{
					ddown = vertical._data.Count() - 1 - x;
				}
				if (vertical._data[b].height >= height & ddown < 0)
				{
					ddown  = b - x;
					b = vertical._data.Count() + 2;
				}
				b = b + 1;
			}
			return dup * ddown * dleft * dright;
		}
	}
	public class InputDataDay08 : InputDataDayXX
	{
		List<gridLocation> _gridLocations = new List<gridLocation>();
		List<line> _lines = new List<line>();
		// Cast the data to the required type.	
		// Constructor
		public InputDataDay08(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			int j = 0;
			while (i < _rawdata.Count())
			{
				_rawdata[i] = _rawdata[i].Trim().Replace("\r","");
				_lines.Add(new line());
				while (j < _rawdata[i].Length)
				{
					int height = Int32.Parse(_rawdata[i][j].ToString());
					gridLocation _gridlocation = new gridLocation(i,j,height);
					_gridLocations.Add(_gridlocation);
					_lines[i]._data.Add(_gridlocation);
					j = j + 1;
				}
				j = 0;
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
				while (i < _lines.Count())
				{
					_lines[i]._data[_lines[0]._data.Count() - 1].visible = true;
					while (j < _lines[0]._data.Count())
					{
						if (i == 0 | i == _lines.Count() -1)
						{
							_lines[i]._data[j].visible = true;
						}
						if (j == 0)
						{
							_lines[i].maxleft = _lines[i]._data[0].height;
							_lines[i].maxright = _lines[i]._data[_lines[i]._data.Count() - 1].height;
							_lines[i]._data[j].visible = true;
						}
						if (_lines[i]._data[j].height > _lines[i].maxleft)
						{
							_lines[i]._data[j].visible = true;
							_lines[i].maxleft = _lines[i]._data[j].height;
						}
						j = j + 1;
					}
					j = _lines[i]._data.Count - 2;
					while (j > 0 & _lines[i]._data[j].visible == false)
					{
						if (_lines[i]._data[j].height > _lines[i].maxright)
						{
							_lines[i]._data[j].visible = true;
							_lines[i].maxright = _lines[i]._data[j].height;
						}
						j = j - 1;
					}
					j = _lines[i]._data.Count();
					j = 0;
					i = i + 1;
				}
				///////////////////////////////////
				//////////////////////////////////
				//////////////////////////////////
				i = 0;
				j = 0;
				while (j < _lines[0]._data.Count())
				{
					int maxtop = 0;
					int maxbottom = 0;
					while (i < _lines.Count())
					{
						if (i == 0)
						{
							maxtop = _lines[0]._data[j].height;
							maxbottom = _lines[_lines.Count() - 1]._data[j].height;
							_lines[i]._data[j].visible = true;
						}
						if (_lines[i]._data[j].height > maxtop)
						{
							_lines[i]._data[j].visible = true;
							maxtop = _lines[i]._data[j].height;
						}
						i = i + 1;
					}
					i = _lines.Count() - 2;
					while (i > 0) // & _lines[i]._data[j].visible == false)
					{
						if (_lines[i]._data[j].height > maxbottom)
						{
							_lines[i]._data[j].visible = true;
							maxbottom = _lines[i]._data[j].height;
						}
						i = i - 1;
					}
					i = _lines.Count();
					i = 0;
					j = j + 1;
				}
				i = 0;
				j = 0;
				while (i < _lines.Count())
				{
					j = j + _lines[i]._data.FindAll(x => x.visible == true).Count();
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
				int score = 0;
				List<line> verticalLines = new List<line>();
				while (i < _lines[0]._data.Count())
				{
					verticalLines.Add(new line());
					while (j < _lines.Count())
					{
						verticalLines[i]._data.Add(_lines[j]._data[i]);
						j = j + 1;
					}
					j = 0;
					i = i + 1;
				}
				i = 0;
				j = 0;
				while (i < _lines.Count())
					{
						while (j < _lines[0]._data.Count())
						{
							if (i > 0 & j > 0 & i < _lines.Count() - 1 & j < _lines.Count -1 & _lines[i]._data[j].visible == true)
							{
								line verticalline = new line();
								int currentScore = _lines[i]._data[j].getScore(_lines[i],verticalLines[j],i,j);
								if (currentScore > score)
								{
									score = currentScore;
								}
							}
							j = j + 1;
						}
						j = 0;
						i = i + 1;
					}
				return score;
			}
	
		}
	}
}
