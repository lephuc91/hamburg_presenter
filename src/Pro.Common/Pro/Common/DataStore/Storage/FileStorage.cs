using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows.Threading;
using Pro.Common.Logging;

namespace Pro.Common.DataStore.Storage;

internal class FileStorage : IStorage
{
	private static readonly TimeSpan WriteDelayTime = TimeSpan.FromSeconds(2.0);

	private readonly string _filename;

	private readonly bool _allowWriting;

	private bool _isLoaded;

	private readonly Dictionary<string, string> _fileCache = new Dictionary<string, string>();

	private readonly DispatcherTimer? _writeTimer;

	[GeneratedRegex("^(.+?)=(.*);(?:$|\\s*\\#.*)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex KeyValuePattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__KeyValuePattern_0.Instance;
	}

	public FileStorage(string filename, bool allowWriting = true, bool groupWrites = true)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		_filename = filename;
		_allowWriting = allowWriting;
		if (groupWrites)
		{
			_writeTimer = new DispatcherTimer((DispatcherPriority)4);
			_writeTimer.Interval = WriteDelayTime;
			_writeTimer.Tick += OnWriteFile;
		}
	}

	public bool TryReadValue(string key, [NotNullWhen(true)] out string? value)
	{
		lock (_fileCache)
		{
			EnsureFileLoaded();
			return _fileCache.TryGetValue(key, out value);
		}
	}

	public void WriteValue(string key, string value)
	{
		if (!_allowWriting)
		{
			throw new Exception("Storage is read-only");
		}
		lock (_fileCache)
		{
			EnsureFileLoaded();
			_fileCache[key] = value;
			if (_writeTimer != null)
			{
				_writeTimer.Stop();
				_writeTimer.Start();
			}
			else
			{
				WriteFile();
			}
		}
	}

	public void RemoveValue(string key)
	{
		if (!_allowWriting)
		{
			throw new Exception("Storage is read-only");
		}
		lock (_fileCache)
		{
			EnsureFileLoaded();
			_fileCache.Remove(key);
			if (_writeTimer != null)
			{
				_writeTimer.Stop();
				_writeTimer.Start();
			}
			else
			{
				WriteFile();
			}
		}
	}

	private void EnsureFileLoaded()
	{
		if (_isLoaded)
		{
			return;
		}
		_isLoaded = true;
		_fileCache.Clear();
		if (!File.Exists(_filename))
		{
			return;
		}
		foreach (string item in File.ReadLines(_filename))
		{
			string text = item.Trim();
			if (!text.StartsWith('#'))
			{
				Match match = KeyValuePattern().Match(text);
				if (match.Success)
				{
					_fileCache[match.Groups[1].Value] = match.Groups[2].Value.Unescape();
				}
			}
		}
	}

	private void OnWriteFile(object? sender, EventArgs e)
	{
		WriteFile();
	}

	private void WriteFile()
	{
		lock (_fileCache)
		{
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(_filename) ?? string.Empty);
				using StreamWriter streamWriter = new StreamWriter(new FileStream(_filename, FileMode.Create, FileAccess.Write));
				foreach (KeyValuePair<string, string> item in _fileCache)
				{
					streamWriter.WriteLine($"{item.Key}={item.Value?.Escape() ?? string.Empty};");
				}
			}
			catch (UnauthorizedAccessException value)
			{
				Log.Error($"Unable to access file \"{_filename}\" with error :{value}");
			}
			finally
			{
				DispatcherTimer? writeTimer = _writeTimer;
				if (writeTimer != null)
				{
					writeTimer.Stop();
				}
			}
		}
	}

	public void Reload()
	{
		lock (_fileCache)
		{
			_isLoaded = false;
		}
	}

	public void UpdateSettingsFile()
	{
		lock (_fileCache)
		{
			EnsureFileLoaded();
			WriteFile();
		}
	}
}
