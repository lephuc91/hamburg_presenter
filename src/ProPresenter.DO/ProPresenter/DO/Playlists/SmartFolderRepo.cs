using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Playlists;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_folderWatcher", "_fileWatcher" })]
public class SmartFolderRepo : ISmartFolderRepo, ICloneable<ISmartFolderRepo?>, IDisposable
{
	private RelativePath _targetFolder;

	private FileWatcher? _fileWatcher;

	private FileWatcher? _folderWatcher;

	private Dispatcher? _dispatcher;

	private readonly List<string> _pendingFiles = new List<string>();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Name
	{
		get
		{
			if (string.IsNullOrWhiteSpace(_targetFolder))
			{
				return LocalizedStrings.Get("PLAYLIST_GLOBAL_PLAYLIST_title");
			}
			return Path.GetFileName(_targetFolder);
		}
	}

	public string TargetPath => _targetFolder.FullPath ?? string.Empty;

	public event Action<RelativePath>? FileCreated;

	public event Action<RelativePath>? FileDeleted;

	public event Action<RelativePath, RelativePath>? FileRenamed;

	public event Action<RelativePath>? FileChanged;

	public event Action<IEnumerable<RelativePath>>? FilesParsed;

	public SmartFolderRepo(RelativePath targetFolder)
	{
		_targetFolder = targetFolder;
		SetUpFolder(targetFolder);
	}

	public void SetUpFolder(RelativePath folder)
	{
		_targetFolder = folder;
		if (!string.IsNullOrWhiteSpace(folder) && PermissionChecker.HasReadPermission(folder.FullPath))
		{
			SetupFileWatcher(folder);
			SetupFolderWatcher(folder);
		}
	}

	public void SetupFileWatcher(RelativePath targetFolder)
	{
		if (targetFolder.IsValid)
		{
			if (_fileWatcher != null)
			{
				_fileWatcher.EnableRaisingEvents = false;
				_fileWatcher.Created -= OnFileCreated;
				_fileWatcher.Deleted -= OnFileDeleted;
				_fileWatcher.Renamed -= OnFileRenamed;
				_fileWatcher.Changed -= OnFileChanged;
				_fileWatcher.Dispose();
			}
			_fileWatcher = new FileWatcher(targetFolder, "*.*");
			_fileWatcher.Created += OnFileCreated;
			_fileWatcher.Deleted += OnFileDeleted;
			_fileWatcher.Renamed += OnFileRenamed;
			_fileWatcher.Changed += OnFileChanged;
			_fileWatcher.EnableRaisingEvents = true;
			_dispatcher = Dispatcher.CurrentDispatcher;
		}
	}

	public void SetupFolderWatcher(RelativePath targetFolder)
	{
		if (targetFolder.IsValid)
		{
			string path = Directory.GetParent(targetFolder)?.FullName ?? ((string)targetFolder);
			string fileName = Path.GetFileName(targetFolder);
			if (_folderWatcher != null)
			{
				_folderWatcher.EnableRaisingEvents = false;
				_folderWatcher.Created -= OnFolderCreated;
				_folderWatcher.Deleted -= OnFolderDeleted;
				_folderWatcher.Renamed -= OnFolderRenamed;
				_folderWatcher.Dispose();
			}
			_folderWatcher = new FileWatcher(path, fileName);
			_folderWatcher.Created += OnFolderCreated;
			_folderWatcher.Deleted += OnFolderDeleted;
			_folderWatcher.Renamed += OnFolderRenamed;
			_folderWatcher.EnableRaisingEvents = true;
		}
	}

	public void ParseFiles()
	{
		if (string.IsNullOrWhiteSpace(_targetFolder) || !_targetFolder.IsValid || !PermissionChecker.HasReadPermission(_targetFolder))
		{
			return;
		}
		try
		{
			NaturalStringComparer comparer = new NaturalStringComparer();
			RelativePath[] obj = (from f in Directory.GetFiles(_targetFolder, "*.*", SearchOption.AllDirectories)
				select new RelativePath(f) into f
				where f.FullPath?.IsValidMediaFilenameToHandle() ?? false
				select f).OrderBy((RelativePath f) => f, comparer).ToArray();
			this.FilesParsed?.Invoke(obj);
		}
		catch (Exception value)
		{
			Log.Error($"Error while parsing smart playlist folder: {value}");
		}
	}

	public void ImportFiles(IEnumerable<string> filenames)
	{
		if (string.IsNullOrWhiteSpace(_targetFolder) || !_targetFolder.IsValid)
		{
			return;
		}
		foreach (string filename in filenames)
		{
			string text = Path.GetFullPath(Path.Combine(path2: Path.GetFileName(filename), path1: _targetFolder));
			if (File.Exists(text))
			{
				text = FileHelper.GenerateNewFilename(text);
			}
			File.Copy(filename, text, overwrite: true);
		}
	}

	public ISmartFolderRepo Clone()
	{
		return new SmartFolderRepo(_targetFolder);
	}

	public URL Serialize()
	{
		return _targetFolder.Serialize();
	}

	public void Deserialize(Playlist.Types.FolderDirectory protoFolderDirectory)
	{
		SetUpFolder(new RelativePath(protoFolderDirectory.SmartDirectory));
	}

	private void OnFileCreated(object sender, FileSystemEventArgs e)
	{
		if (new FileInfo(e.FullPath).Attributes.HasFlag(FileAttributes.Directory))
		{
			ParseFiles();
			return;
		}
		if (!_pendingFiles.Contains(e.FullPath))
		{
			_pendingFiles.Add(e.FullPath);
		}
		if (!e.FullPath.IsValidMediaFilenameToHandle())
		{
			return;
		}
		_pendingFiles.Remove(e.FullPath);
		Dispatcher? dispatcher = _dispatcher;
		if (dispatcher != null)
		{
			dispatcher.InvokeAsync((System.Action)delegate
			{
				this.FileCreated?.Invoke((RelativePath)e.FullPath);
			});
		}
	}

	private void OnFileDeleted(object sender, FileSystemEventArgs e)
	{
		_pendingFiles.Remove(e.FullPath);
		Dispatcher? dispatcher = _dispatcher;
		if (dispatcher != null)
		{
			dispatcher.InvokeAsync((System.Action)delegate
			{
				this.FileDeleted?.Invoke((RelativePath)e.FullPath);
			});
		}
	}

	private void OnFileRenamed(object sender, RenamedEventArgs e)
	{
		if (_pendingFiles.Contains(e.OldFullPath))
		{
			_pendingFiles.Remove(e.OldFullPath);
			_pendingFiles.Add(e.FullPath);
		}
		Dispatcher? dispatcher = _dispatcher;
		if (dispatcher != null)
		{
			dispatcher.InvokeAsync((System.Action)delegate
			{
				this.FileRenamed?.Invoke((RelativePath)e.OldFullPath, (RelativePath)e.FullPath);
			});
		}
	}

	private void OnFileChanged(object sender, FileSystemEventArgs e)
	{
		if (!e.FullPath.IsValidMediaFilenameToHandle())
		{
			return;
		}
		Dispatcher? dispatcher = _dispatcher;
		if (dispatcher == null)
		{
			return;
		}
		dispatcher.InvokeAsync((System.Action)delegate
		{
			if (_pendingFiles.Contains(e.FullPath))
			{
				_pendingFiles.Remove(e.FullPath);
				this.FileCreated?.Invoke((RelativePath)e.FullPath);
			}
			else
			{
				this.FileChanged?.Invoke((RelativePath)e.FullPath);
			}
		});
	}

	private void OnFolderCreated(object sender, FileSystemEventArgs e)
	{
		RelativePath targetFolder = (RelativePath)e.FullPath;
		SetupFileWatcher(targetFolder);
		ParseFiles();
	}

	private void OnFolderDeleted(object sender, FileSystemEventArgs e)
	{
		if (_fileWatcher != null)
		{
			_fileWatcher.EnableRaisingEvents = false;
			_fileWatcher.Dispose();
		}
	}

	private void OnFolderRenamed(object sender, RenamedEventArgs e)
	{
		if (e.Name != _folderWatcher?.Filter && _fileWatcher != null)
		{
			_fileWatcher.EnableRaisingEvents = false;
			_fileWatcher.Dispose();
		}
		else
		{
			ParseFiles();
		}
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
			_folderWatcher?.Dispose();
			_fileWatcher?.Dispose();
		}
	}
}
