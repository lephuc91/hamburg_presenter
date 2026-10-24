using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Operations;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;

namespace Pro.Serialization.DataManagement;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_fileWatcher" })]
public abstract class SyncedFileData<S, K, T> : ISyncedFileData<K, T>, IDisposable where S : SyncedFileData<S, K, T> where K : class where T : class
{
	private sealed class DataModel
	{
		private Clock? _readBlackoutTimer;

		public K? Data { get; set; }

		public T Model { get; }

		public bool ExpectingChange { get; private set; }

		public bool IsReadBlackedOut
		{
			get
			{
				if (_readBlackoutTimer != null)
				{
					return _readBlackoutTimer.ElapsedTime < SyncedFileData<S, K, T>.ReadBlackoutDelay;
				}
				return false;
			}
		}

		public DataModel(K? data, T model)
		{
			Data = data;
			Model = model;
		}

		public void StartExpectingChange()
		{
			ExpectingChange = true;
			if (_readBlackoutTimer == null)
			{
				_readBlackoutTimer = new Clock();
			}
			_readBlackoutTimer.Restart();
		}

		public void StopExpectingChange()
		{
			ExpectingChange = false;
			_readBlackoutTimer = null;
		}

		public bool AcceptChange()
		{
			if (ExpectingChange)
			{
				ExpectingChange = false;
				return false;
			}
			return !IsReadBlackedOut;
		}
	}

	private sealed class WriteData
	{
		public K? Data { get; set; }

		public Clock Timer { get; } = new Clock(autoStart: true);
	}

	private static readonly TimeSlice WriteTimerInterval = TimeSlice.FromSeconds(0.5);

	private static readonly TimeSlice WriteTimerDelay = TimeSlice.FromSeconds(2.0);

	private static readonly TimeSlice ReadBlackoutDelay = TimeSlice.FromSeconds(2.0);

	private bool _filesLoaded;

	private readonly IErrorReporter _errorReporter;

	private readonly string? _targetExtension;

	private FileWatcher _fileWatcher;

	private readonly ConcurrentDictionary<string, DataModel> _mappedData = new ConcurrentDictionary<string, DataModel>();

	private readonly DispatcherTimer _writeTimer = new DispatcherTimer((DispatcherPriority)4);

	private readonly ConcurrentDictionary<string, WriteData> _writeQueue = new ConcurrentDictionary<string, WriteData>();

	private readonly LockingList<string> _knownDeletions = new LockingList<string>();

	private readonly SyncedFileDeserializeDelegate<S, K, T?> _deserializeFile;

	private readonly SyncedFileLoadedDelegate<S, T> _fileLoaded;

	private readonly SyncedFileDeletedDelegate<S, T> _fileDeleted;

	private readonly SyncedFileRenamedDelegate<S, T> _fileRenamed;

	private readonly SyncedFileUpdatedDelegate<S, K, T> _fileUpdated;

	private readonly SyncedFileValidateParseDelegate<S, K?>? _validateParse;

	private readonly SyncedFilePrefixFileDelegate? _prefixFile;

	private bool _reportFileWriteException = true;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string TargetDirectory { get; private set; }

	private bool UseFilePrefix => _prefixFile != null;

	public event Action? AllFilesLoaded;

	protected SyncedFileData(IErrorReporter errorReporter, string? targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<S, K, T?> deserializeFile, SyncedFileLoadedDelegate<S, T> fileLoaded, SyncedFileDeletedDelegate<S, T> fileDeleted, SyncedFileRenamedDelegate<S, T> fileRenamed, SyncedFileUpdatedDelegate<S, K, T> fileUpdated, SyncedFileValidateParseDelegate<S, K?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_errorReporter = errorReporter;
		_targetExtension = targetExtension;
		_deserializeFile = deserializeFile;
		_fileLoaded = fileLoaded;
		_fileDeleted = fileDeleted;
		_fileRenamed = fileRenamed;
		_fileUpdated = fileUpdated;
		_validateParse = validateParse;
		_prefixFile = prefixFile;
		_writeTimer.Interval = WriteTimerInterval;
		_writeTimer.Tick += OnWriteFiles;
		TargetDirectory = OnInitializeTargetDirectory(targetDirectory);
	}

	[MemberNotNull("_fileWatcher")]
	private string OnInitializeTargetDirectory(string targetDirectory)
	{
		targetDirectory = targetDirectory.NormalizePath();
		_filesLoaded = false;
		_fileWatcher = new FileWatcher(targetDirectory, "*");
		_fileWatcher.Created += FileCreated;
		_fileWatcher.Deleted += FileDeleted;
		_fileWatcher.Renamed += FileRenamed;
		_fileWatcher.Changed += FileChanged;
		_fileWatcher.IncludeSubdirectories = UseFilePrefix;
		_fileWatcher.EnableRaisingEvents = true;
		_writeTimer.Start();
		return targetDirectory;
	}

	protected abstract bool OnTryParseFile(string name, string fullPath, out K? data);

	protected abstract bool OnWriteFile(string name, string fullPath, K data);

	private string GetFilePrefix(string name)
	{
		return _prefixFile?.Invoke(name) ?? string.Empty;
	}

	private bool TryParseFile(string name, string fullPath, out K? data)
	{
		if (OnTryParseFile(name, fullPath, out data))
		{
			return _validateParse?.Invoke((S)this, name, data) ?? true;
		}
		return false;
	}

	private void WriteFile(string name, K? data)
	{
		_writeQueue.AddOrUpdate(name, (string _) => new WriteData
		{
			Data = data
		}, delegate(string key, WriteData existingValue)
		{
			existingValue.Data = data;
			return existingValue;
		});
	}

	private void OnWriteFiles(object? sender, EventArgs e)
	{
		WriteFiles();
	}

	private void WriteFiles(bool forceWrite = false)
	{
		foreach (KeyValuePair<string, WriteData> item in _writeQueue)
		{
			if (!forceWrite && item.Value.Timer.ElapsedTime < WriteTimerDelay)
			{
				continue;
			}
			string key = item.Key;
			if (!_writeQueue.TryRemove(key, out WriteData _) || string.IsNullOrEmpty(key))
			{
				continue;
			}
			string text = GenerateFullPath(key);
			try
			{
				if (_mappedData.TryGetValue(key, out DataModel value2))
				{
					value2.StartExpectingChange();
				}
				string directoryName = Path.GetDirectoryName(text);
				if (!string.IsNullOrWhiteSpace(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				if (item.Value.Data != null)
				{
					OnWriteFile(key, text, item.Value.Data);
				}
			}
			catch (Exception ex)
			{
				if (_reportFileWriteException)
				{
					_reportFileWriteException = false;
					_errorReporter.Error("Error trying to write file: \"{0}\"; \"{1}\"", text, ex);
				}
				Log.Error("Error trying to write file: \"{0}\"; \"{1}\"", text, ex);
			}
		}
	}

	public void CommitAllInWriteQueue()
	{
		WriteFiles(forceWrite: true);
	}

	public void AddSyncedFile(string name, K? data, T model)
	{
		if (!_mappedData.TryAdd(name, new DataModel(data, model)))
		{
			throw new Exception("File with name " + name + " already exists");
		}
		WriteFile(name, data);
	}

	public void AddSyncedFile(string fullPath)
	{
		if (!string.IsNullOrEmpty(fullPath))
		{
			AddFile(GenerateFileKey(fullPath), fullPath);
		}
	}

	public void RenameSyncedFile(T model, string newFilename)
	{
		if (string.IsNullOrEmpty(newFilename))
		{
			return;
		}
		if (UseFilePrefix)
		{
			throw new NotImplementedException();
		}
		string keyFromMappedData = GetKeyFromMappedData(model);
		if (string.IsNullOrEmpty(keyFromMappedData) || newFilename == keyFromMappedData || !_mappedData.TryRemove(keyFromMappedData, out DataModel value))
		{
			return;
		}
		_writeQueue.TryRemove(keyFromMappedData, out WriteData _);
		if (AddFileToMap(newFilename, value))
		{
			string text = GenerateFullPath(keyFromMappedData);
			if (File.Exists(text))
			{
				string destFileName = GenerateFullPath(newFilename);
				File.Move(text, destFileName);
			}
		}
	}

	public void DeleteSyncedFile(T model)
	{
		string keyFromMappedData = GetKeyFromMappedData(model);
		if (!string.IsNullOrEmpty(keyFromMappedData))
		{
			_mappedData.TryRemove(keyFromMappedData, out DataModel _);
			_writeQueue.TryRemove(keyFromMappedData, out WriteData _);
			_knownDeletions.Add(keyFromMappedData);
			string text = GenerateFullPath(keyFromMappedData);
			if (UseFilePrefix)
			{
				text = GetFilePrefix(text);
			}
			FileHelper.MoveToRecycleBin(text);
		}
	}

	public string GenerateFullPath(string name)
	{
		return Path.Combine(TargetDirectory, GetFilePrefix(name), Path.GetFileName(name)) + _targetExtension;
	}

	public void UpdateSyncedFile(K? data, T model)
	{
		string keyFromMappedData = GetKeyFromMappedData(model);
		if (!string.IsNullOrEmpty(keyFromMappedData) && _mappedData.TryGetValue(keyFromMappedData, out DataModel value))
		{
			value.Data = data;
			WriteFile(keyFromMappedData, data);
		}
	}

	public void UpdateSyncedFile(string newKey, T model)
	{
		string keyFromMappedData = GetKeyFromMappedData(model);
		if (!string.IsNullOrEmpty(keyFromMappedData) && !(newKey == keyFromMappedData) && _mappedData.TryRemove(keyFromMappedData, out DataModel value))
		{
			AddFileToMap(newKey, value);
		}
	}

	public bool TryGetParsedData(T model, out K? data)
	{
		data = null;
		string keyFromMappedData = GetKeyFromMappedData(model);
		if (string.IsNullOrEmpty(keyFromMappedData) || !_mappedData.TryGetValue(keyFromMappedData, out DataModel value))
		{
			return false;
		}
		data = value.Data;
		return true;
	}

	public void Move(string newPath)
	{
		WriteFiles(forceWrite: true);
		_writeTimer.Stop();
		_fileWatcher.Dispose();
		Directory.Move(TargetDirectory, newPath);
		TargetDirectory = OnInitializeTargetDirectory(newPath);
	}

	private void FileCreated(object sender, FileSystemEventArgs e)
	{
		if (File.Exists(e.FullPath))
		{
			string text = GenerateFileKey(e.FullPath);
			if (!_mappedData.ContainsKey(text))
			{
				AddFile(text, e.FullPath, expectingChange: true);
			}
		}
	}

	private void FileDeleted(object sender, FileSystemEventArgs e)
	{
		string text = GenerateFileKey(e.FullPath);
		if (!_knownDeletions.Remove(text) && _mappedData.TryRemove(text, out DataModel value))
		{
			_writeQueue.TryRemove(text, out WriteData _);
			_fileDeleted((S)this, text, value.Model);
		}
	}

	private void FileRenamed(object sender, RenamedEventArgs e)
	{
		if (File.Exists(e.FullPath))
		{
			string text = GenerateFileKey(e.FullPath);
			string text2 = GenerateFileKey(e.OldFullPath);
			if (_mappedData.TryRemove(text2, out DataModel value) && AddFileToMap(text, value))
			{
				_fileRenamed((S)this, text2, text, value.Model);
			}
		}
	}

	private void FileChanged(object sender, FileSystemEventArgs e)
	{
		if (!File.Exists(e.FullPath))
		{
			return;
		}
		string text = GenerateFileKey(e.FullPath);
		if (_mappedData.TryGetValue(text, out DataModel value) && value.AcceptChange() && TryParseFile(text, e.FullPath, out K data))
		{
			value.Data = data;
			if (data != null)
			{
				_fileUpdated((S)this, text, data, value.Model);
			}
		}
	}

	private string GetKeyFromMappedData(T model)
	{
		return _mappedData.FirstOrDefault<KeyValuePair<string, DataModel>>((KeyValuePair<string, DataModel> d) => d.Value.Model.Equal(model)).Key;
	}

	private string GenerateFileKey(string fullPath)
	{
		return Path.ChangeExtension(TargetDirectory.GetPathRelativeTo(fullPath), null);
	}

	private FileIOResult AddFile(string fileKey, string fullPath, bool expectingChange = false)
	{
		if (!TryParseFile(fileKey, fullPath, out K data))
		{
			return FileIOResult.InvalidOperation(fullPath);
		}
		if (data == null)
		{
			return FileIOResult.Success();
		}
		T val = _deserializeFile((S)this, fileKey, data);
		if (val == null)
		{
			return FileIOResult.InvalidArgument(fullPath);
		}
		DataModel dataModel = new DataModel(data, val);
		if (expectingChange)
		{
			dataModel.StartExpectingChange();
		}
		if (AddFileToMap(fileKey, dataModel))
		{
			_fileLoaded((S)this, val);
		}
		else if (dataModel.ExpectingChange)
		{
			dataModel.StopExpectingChange();
		}
		return FileIOResult.Success();
	}

	private bool AddFileToMap(string key, DataModel dataModel)
	{
		return _mappedData.TryAdd(key, dataModel);
	}

	protected void ParseAllFiles()
	{
		if (_filesLoaded)
		{
			return;
		}
		_filesLoaded = true;
		string text = string.Empty;
		try
		{
			if (!Directory.Exists(TargetDirectory))
			{
				return;
			}
			string[] files = Directory.GetFiles(TargetDirectory, "*" + _targetExtension, UseFilePrefix ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			foreach (string text2 in files)
			{
				if (!new FileInfo(text2).Attributes.HasFlag(FileAttributes.Hidden))
				{
					text = text2;
					AddFile(GenerateFileKey(text), text);
				}
			}
		}
		catch (Exception ex)
		{
			_errorReporter.Error("Error encountered while parsing file: \"{0}\"; \"{1}\"", text, ex);
		}
		this.AllFilesLoaded?.Invoke();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_fileWatcher.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		WriteFiles(forceWrite: true);
		_writeTimer.Stop();
	}
}
