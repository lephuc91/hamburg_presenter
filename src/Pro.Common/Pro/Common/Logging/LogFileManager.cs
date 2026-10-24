using System;
using System.IO;
using System.Text;
using Pro.Common.FileSystem;
using Pro.Common.Time;

namespace Pro.Common.Logging;

public static class LogFileManager
{
	private static string? _rootPath;

	private static string? _logName;

	private static LogSettings? _settings;

	private static string GetLogFilePath(string rootPath, string logName)
	{
		return Path.Combine(rootPath, logName + ".log");
	}

	private static string GetLogFilePath(int index = 0)
	{
		return GetLogFilePath(GetLogPath(), _logName + ((index <= 0) ? string.Empty : $".{index}"));
	}

	private static string GetLogPath()
	{
		if (_rootPath == null)
		{
			throw new IOException("Log file root path not defined");
		}
		return _rootPath;
	}

	public static string StartLogging(string rootPath, string logName, Encoding encoding)
	{
		if (!Directory.Exists(rootPath))
		{
			Directory.CreateDirectory(rootPath);
		}
		_rootPath = rootPath;
		_logName = GetValidLogFilename(_rootPath, logName);
		_settings = new LogSettings(Path.Combine(rootPath, logName + ".proPref"));
		RotateLogs();
		string logFilePath = GetLogFilePath();
		Log.AddOutput(new StreamWriter(logFilePath, encoding, new FileStreamOptions
		{
			Access = FileAccess.Write,
			Mode = FileMode.Append,
			Share = FileShare.Read
		}));
		return logFilePath;
	}

	private static string GetValidLogFilename(string rootPath, string baseLogFileName)
	{
		if ((bool)FileHelper.WaitForFileAccess(GetLogFilePath(rootPath, baseLogFileName), enforceFileExists: false, TimeSlice.FromMilliseconds(1.0)))
		{
			return baseLogFileName;
		}
		for (char c = 'a'; c <= 'z'; c = (char)(c + 1))
		{
			string text = $"{baseLogFileName}.{c}";
			if ((bool)FileHelper.WaitForFileAccess(GetLogFilePath(rootPath, text), enforceFileExists: false, TimeSlice.FromMilliseconds(1.0)))
			{
				return text;
			}
		}
		throw new IOException("Unable to find accessible log file base name.");
	}

	private static void RotateLogs()
	{
		if (_settings == null)
		{
			throw new InvalidOperationException();
		}
		if (!(DateTime.Now - _settings.LastRotation >= _settings.RotateTime))
		{
			return;
		}
		_settings.LastRotation = DateTime.Now;
		bool flag = true;
		FileInfo[] files = new DirectoryInfo(GetLogPath()).GetFiles();
		for (int num = _settings.MaxLogs - 1; num >= 0; num--)
		{
			string logFilenameWithoutExtension = _logName + ((num <= 0) ? string.Empty : $".{num}");
			FileInfo fileInfo = Array.Find(files, (FileInfo f) => Path.GetFileNameWithoutExtension(f.Name) == logFilenameWithoutExtension);
			if (fileInfo != null)
			{
				if (flag)
				{
					fileInfo.Delete();
				}
				else
				{
					string logFilePath = GetLogFilePath(num + 1);
					fileInfo.MoveTo(logFilePath);
				}
			}
			flag = false;
		}
	}
}
