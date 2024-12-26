using System.IO;

namespace Aoc2022.Logging
{

	//https://www.tutorialsteacher.com/csharp/singleton
	//Singleton Logger
	public class Logger : IDisposable
	{
		static string _filename;
		static StreamWriter _sw;
		static FileStream _fs;
		static string _category;
		static LogLevel _level;
		
		private static Logger _instance;

		private Logger()
		{
			if (_category == null)
            {
                _category = "default";
            }
            _filename =  $"./Logs/{_category}.log";
            _fs = new FileStream(_filename, FileMode.Append);
            _sw = new StreamWriter(_fs);
            
		}
		
		public static Logger Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Logger();
				}
				return _instance;
			}
		}

		public static string Category 
		{
			get => _category;
			set
			{
				_category = value;
			}
		}

		public static LogLevel Level
		{
			get => _level;
			set
			{
				_level = value;
			}
		}

		public void Log(LogLevel level, string message)
		{
			switch (level)
			{
				case (LogLevel.DEBUG):
					LogDebug(message);
					break;
				case (LogLevel.INFO):
					LogInformation(message);
					break;
				case (LogLevel.WARNING):
					LogWarning(message);
					break;
				case (LogLevel.ERROR):
					LogError(message);
					break;
				case (LogLevel.CRITICAL):
					LogCritical(message);
					break;
				default:
					break;
			}
		}

		public void LogInformation(string message)
		{
			if (_level <= LogLevel.INFO)	
			{
				DateTime _dateTime = DateTime.Now;
				string _msgTxt = $"{_dateTime.ToString("s")} : [INFO] : {message}";
				_Log(_msgTxt);	
			}

		}

		public void LogDebug(string message)
		{
				
			if (_level <= LogLevel.DEBUG)	
			{
				DateTime _dateTime = DateTime.Now;
				string _msgTxt = $"{_dateTime.ToString("s")} : [DEBUG] : {message}";
				_Log(_msgTxt);	
			}

		}
		
		public void LogWarning(string message)
		{
			
			if (_level <= LogLevel.WARNING)	
			{
				DateTime _dateTime = DateTime.Now;
				string _msgTxt = $"{_dateTime.ToString("s")} : [WARN] : {message}";
				_Log(_msgTxt);	
			}

		}
		
		public void LogError(string message)
		{

			if (_level <= LogLevel.ERROR)	
			{
				DateTime _dateTime = DateTime.Now;
				string _msgTxt = $"{_dateTime.ToString("s")} : [ERR] : {message}";
				_Log(_msgTxt);	
			}

		}

		public void LogCritical(string message)
		{

			if (_level <= LogLevel.CRITICAL)	
			{
				DateTime _dateTime = DateTime.Now;
				string _msgTxt = $"{_dateTime.ToString("s")} : [CRIT] : {message}";
				_Log(_msgTxt);	
			}

		}

		private void _Log(string msg)
		{
			Console.WriteLine(msg);
			_sw.WriteLine(msg);
		}

		public void Dispose()
		{
			_sw.Close();
			_fs.Close();

		}
	}


	public enum LogLevel
	{
		DEBUG,
		INFO,
		WARNING,
		ERROR,
		CRITICAL
	}

	
}
