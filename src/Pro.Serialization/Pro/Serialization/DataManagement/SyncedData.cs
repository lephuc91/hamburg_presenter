using System;
using System.IO;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Time;

namespace Pro.Serialization.DataManagement;

public abstract class SyncedData<S, T> : DisposableBase, ISyncedData<S, T>, IDisposable where S : SyncedData<S, T> where T : class
{
	private static readonly TimeSlice WriteDelay = TimeSlice.FromSeconds(2.0);

	private static readonly TimeSlice ReadBlackoutDelay = TimeSlice.FromSeconds(3.0);

	private string _targetDirectory = string.Empty;

	private string _targetFilename = string.Empty;

	private string _fullPath = string.Empty;

	private bool _expectingChanges;

	private bool _isReadBlackedOut;

	private FileWatcher? _fileWatcher;

	private bool _fileExists;

	private bool _fileLoaded;

	private bool _hasChanges;

	private readonly DispatcherTimer _readBlackoutTimer = new DispatcherTimer((DispatcherPriority)4);

	private readonly Action<T> _dataUpdated;

	private readonly Action<DataClearSource> _dataCleared;

	private readonly SyncedFileValidateParseDelegate<S, T?>? _validateParse;

	private T? _writeData;

	private readonly DispatcherTimer _writeTimer = new DispatcherTimer((DispatcherPriority)4);

	public string TargetDirectory => _targetDirectory;

	public string TargetFilename => _targetFilename;

	protected SyncedData(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<S, T?>? validateParse = null)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		_dataUpdated = dataUpdated;
		_dataCleared = dataCleared;
		_validateParse = validateParse;
		ChangeTargetDirectoryFilename(targetDirectory, targetFilename);
		_readBlackoutTimer.Interval = ReadBlackoutDelay;
		_readBlackoutTimer.Tick += ReadBlackoutTimer_Tick;
		_writeTimer.Interval = WriteDelay;
		_writeTimer.Tick += WriteTimer_Tick;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		StopExpectingChanges();
		WriteFile();
		_writeTimer.Stop();
		_fileWatcher?.Dispose();
		_fileWatcher = null;
	}

	public void ChangeTargetDirectoryFilename(string targetDirectory, string targetFilename)
	{
		if (!_targetDirectory.Equals(targetDirectory) || !_targetFilename.Equals(targetFilename))
		{
			StopExpectingChanges();
			WriteFile();
			if (_fileWatcher != null)
			{
				_fileWatcher.EnableRaisingEvents = false;
				_dataCleared(DataClearSource.TargetChanging);
				_fileWatcher.Created -= FileCreated;
				_fileWatcher.Deleted -= FileDeleted;
				_fileWatcher.Renamed -= FileRenamed;
				_fileWatcher.Changed -= FileChanged;
				_fileWatcher.Dispose();
				_fileWatcher = null;
			}
			_targetDirectory = targetDirectory;
			_targetFilename = targetFilename;
			_fullPath = Path.GetFullPath(Path.Combine(_targetDirectory, _targetFilename));
			_fileLoaded = false;
			_fileWatcher = new FileWatcher(_targetDirectory, _targetFilename);
			_fileWatcher.Created += FileCreated;
			_fileWatcher.Deleted += FileDeleted;
			_fileWatcher.Renamed += FileRenamed;
			_fileWatcher.Changed += FileChanged;
			_fileWatcher.EnableRaisingEvents = true;
			ParseFile();
		}
	}

	protected abstract bool OnTryParseFile(string filename, string fullPath, out T? data);

	protected abstract void OnWriteFile(string filename, string fullPath, T data);

	private bool TryParseFile(string filename, string fullPath, out T? data)
	{
		if (OnTryParseFile(filename, fullPath, out data))
		{
			return _validateParse?.Invoke((S)this, filename, data) ?? true;
		}
		return false;
	}

	public void UpdateData(T data)
	{
		_hasChanges = true;
		_writeData = data;
		_writeTimer.Stop();
		_writeTimer.Start();
	}

	private void StartExpectingChanges()
	{
		_expectingChanges = true;
		_isReadBlackedOut = true;
		_readBlackoutTimer.Stop();
		_readBlackoutTimer.Start();
	}

	private void StopExpectingChanges()
	{
		_expectingChanges = false;
		_isReadBlackedOut = false;
		_readBlackoutTimer.Stop();
	}

	private void FileCreated(object sender, FileSystemEventArgs e)
	{
		T data;
		if (!_fileExists)
		{
			_fileExists = true;
		}
		else if (OnTryParseFile(_targetFilename, _fullPath, out data) && data != null)
		{
			StartExpectingChanges();
			_dataUpdated(data);
		}
	}

	private void FileDeleted(object sender, FileSystemEventArgs e)
	{
		StopExpectingChanges();
		_dataCleared(DataClearSource.FileRemoved);
	}

	private void FileRenamed(object sender, RenamedEventArgs e)
	{
		StopExpectingChanges();
		string? name = e.Name;
		T data;
		if (name == null || !name.Equals(_targetFilename, StringComparison.OrdinalIgnoreCase))
		{
			_dataCleared(DataClearSource.FileRemoved);
		}
		else if (TryParseFile(_targetFilename, _fullPath, out data) && data != null)
		{
			_dataUpdated(data);
		}
	}

	private void FileChanged(object sender, FileSystemEventArgs e)
	{
		T data;
		if (_expectingChanges)
		{
			_expectingChanges = false;
		}
		else if (!_isReadBlackedOut && TryParseFile(_targetFilename, _fullPath, out data) && data != null)
		{
			_dataUpdated(data);
		}
	}

	protected void ParseFile()
	{
		if (_fileLoaded)
		{
			return;
		}
		_fileExists = File.Exists(_fullPath);
		_fileLoaded = true;
		T data;
		if (!_fileExists)
		{
			_dataCleared(DataClearSource.FileRemoved);
		}
		else if (TryParseFile(_targetFilename, _fullPath, out data))
		{
			if (data != null)
			{
				_dataUpdated(data);
				return;
			}
			Log.Error($"The file {_targetFilename} at {_fullPath} could not be parsed.");
		}
	}

	private void ReadBlackoutTimer_Tick(object? sender, EventArgs e)
	{
		_isReadBlackedOut = false;
		_readBlackoutTimer.Stop();
	}

	private void WriteTimer_Tick(object? sender, EventArgs e)
	{
		WriteFile();
	}

	private void WriteFile()
	{
		if (_hasChanges && _writeData != null)
		{
			StartExpectingChanges();
			OnWriteFile(_targetFilename, _fullPath, _writeData);
		}
		_writeData = null;
		_hasChanges = false;
		_writeTimer.Stop();
	}
}
