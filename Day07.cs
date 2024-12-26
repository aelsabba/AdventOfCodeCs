// Advent of Code 2022, Day07
// https://adventofcode.com/2022/day/7
// @author: Ahmed Elsabbagh "Medo"

using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2022
{

	public class aocFile
	{
		public int _size = new int();
		public string _name = new string("");
		public aocFile(int _s)
		{
			_size = _s;
		}
	}
	public class Folder
		{
		public List<Folder> _subfolders;
		public List<aocFile> _files = new List<aocFile>();
		public Folder _parent;
		public int _size = new int();
		public string _name = new string("");
		public Folder()
		{
		}
		public Folder(string name)
		{
			_subfolders = new List<Folder>();
			_name = name;
		}
		public Folder(Folder _parentf)
		{
			_parent = _parentf;
		}
		public int getSize()
		{
			_size = 0;
			int i = 0;
			while (i < _subfolders.Count())
			{
				_size = _size + _subfolders[i].getSize();
				i = i + 1;
			}
			i = 0;
			while (i < _files.Count())
			{
				_size = _size + _files[i]._size;
				i = i + 1;
			}
			return _size;
		}

		};
	public class InputDataDay07 : InputDataDayXX
	{
		public List<Folder> _folders = new List<Folder>();
		// Cast the data to the required type.	
		// Constructor
		public InputDataDay07(InputDataType dataType, string seperator = "\n", string id = "") :
			base(dataType, seperator, id)
		{
			int i = 0;
			Folder currentFolder = new Folder();
			Folder _root = new Folder("/");
			_folders.Add(_root);
			// Cast to required type
			while (i < _rawdata.Count())
				{
					_rawdata[i] = _rawdata[i].Replace("\r","");
					if (_rawdata[i].Contains("cd"))
					{
						string _row = _rawdata[i].Replace(" cd ","").Replace("$","").Trim();
						if (_row.Contains("/"))
						{
							currentFolder = _root;
						}
						else if (_row.Contains(".."))
						{
							currentFolder = currentFolder._parent;
						}
						else 
						{
							currentFolder = currentFolder._subfolders.Find(x => x._name == _row.Trim());
						}
						i = i + 1;
					}
					else if (_rawdata[i].Contains("ls"))
					{
						i = i + 1;
						bool loop = true;
						while (loop)
						{
							string _row = _rawdata[i].Replace(" cd ","");
							if (_row.Contains("dir"))
							{
								_row = _row.Replace("dir","");
								Folder newFolder = new Folder(_row.Trim());
								newFolder._parent = currentFolder;
								currentFolder._subfolders.Add(newFolder);
								_folders.Add(newFolder);
							}
							else
							{
								int size = Int32.Parse(_row.Split(" ")[0]);
								string name = (_row.Split(" ")[1].Trim());
								aocFile newFile = new aocFile(size);
								newFile._name = name;
								currentFolder._files.Add(newFile);
							}
							i = i + 1;
							if (i < _rawdata.Count())
							{
								loop = (!(_rawdata[i][0] == "$"[0]));
							}
							else
							{
								loop = false;
							}
						}	
					}
				}
		}
		List<int> sizes = new List<int>();


		// Properties
		public override int SolutionToPart1
		{
			get
			{
				int i = 0;
				int output = 0;
				while (i < _folders.Count())
				{
					int size = 0;
					size = _folders[i].getSize();
					sizes.Add(size);
					if (size < 100000)
					{
						output = output + size;
					}
					i = i + 1;
				}
				return output;
			}
		}
		public override int SolutionToPart2
		{
			get
			{
				int i = 0;
				int disk = 70000000;
				int minimum = disk;
				int required = 30000000;
				int used = sizes[0];
				int currentlyEmpty = disk - used;
				int needed = required - currentlyEmpty;
				List<int> diffs = new List<int>();
				List<int> eligiblesizes = new List<int>();
				while (i < sizes.Count())
				{
					if (sizes[i] >= needed){
					diffs.Add((sizes[i] - needed));
					eligiblesizes.Add(sizes[i]);
					}
					i = i + 1;
				}
				return eligiblesizes[diffs.IndexOf(diffs.Min())];
			}
	
		}
	}
}
