using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Logging;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.ChangeDirectory;

public class CrdtProtoDirectoryFileScanner : ICrdtProtoDirectoryFileScanner
{
	private static readonly TimeSpan MINIMUM_FILE_TIMESTAMP_DIFF_TO_CONSIDER_LEGACY = TimeSpan.FromSeconds(10L);

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	public bool ShouldLoadLegacy { get; private set; }

	public CrdtProtoDirectoryFileScanner(IFileSystem fileSystem, ILogger logger)
	{
		_fileSystem = fileSystem;
		_logger = logger;
	}

	public void ValidateWorkspace(IWorkspace workspaceFolder)
	{
		ShouldLoadLegacy = false;
		try
		{
			foreach (IDirectoryInfo item in _fileSystem.Directory.GetDirectories(workspaceFolder.Path).Select(_fileSystem.DirectoryInfo.New))
			{
				if (item.Name switch
				{
					"Configuration" => ProcessConfigurationFiles(item), 
					"Libraries" => ProcessLibrary(item), 
					"Playlists" => ProcessPlaylists(item), 
					"Presets" => ProcessPresets(item), 
					"Themes" => ProcessThemes(item), 
					_ => false, 
				})
				{
					ShouldLoadLegacy = true;
				}
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to scan workspace for discrepancy between crdt and proto. Error - {value}");
		}
	}

	private bool ProcessConfigurationFiles(IDirectoryInfo directory)
	{
		if (!CheckShouldLoadLegacy(directory.FullName, "Calendar") && !CheckShouldLoadLegacy(directory.FullName, "ClearGroups") && !CheckShouldLoadLegacy(directory.FullName, "KeyMappings") && !CheckShouldLoadLegacy(directory.FullName, "Groups") && !CheckShouldLoadLegacy(directory.FullName, "Labels") && !CheckShouldLoadLegacy(directory.FullName, "Macros") && !CheckShouldLoadLegacy(directory.FullName, "Messages") && !CheckShouldLoadLegacy(directory.FullName, "Workspace") && !CheckShouldLoadLegacy(directory.FullName, "CCLI") && !CheckShouldLoadLegacy(directory.FullName, "Stage") && !CheckShouldLoadLegacy(directory.FullName, "Props"))
		{
			return CheckShouldLoadLegacy(directory.FullName, "Timers");
		}
		return true;
	}

	private bool ProcessLibrary(IDirectoryInfo directory)
	{
		return directory.GetFiles("*.pro", SearchOption.AllDirectories).Any((IFileInfo p) => CheckShouldLoadLegacy(p.Directory?.FullName ?? string.Empty, p.Name));
	}

	private bool ProcessPlaylists(IDirectoryInfo directory)
	{
		if (!CheckShouldLoadLegacy(directory.FullName, "Media") && !CheckShouldLoadLegacy(directory.FullName, "Audio") && !CheckShouldLoadLegacy(directory.FullName, "Library"))
		{
			return CheckFolderShouldLoadLegacy(directory, "Templates");
		}
		return true;
	}

	private bool ProcessPresets(IDirectoryInfo directory)
	{
		if (!CheckFolderShouldLoadLegacy(directory, "Effect"))
		{
			return CheckFolderShouldLoadLegacy(directory, "Transition");
		}
		return true;
	}

	private bool CheckFolderShouldLoadLegacy(IDirectoryInfo directory, string subFolder)
	{
		return (from f in directory.GetDirectories(subFolder).SelectMany((IDirectoryInfo d) => d.GetFiles("*"))
			where f.Extension != ".proCloud"
			select f).Any((IFileInfo f) => CheckShouldLoadLegacy(f.Directory?.FullName ?? string.Empty, f.Name));
	}

	private bool ProcessThemes(IDirectoryInfo directory)
	{
		return directory.GetFiles("Theme", SearchOption.AllDirectories).Any((IFileInfo f) => CheckShouldLoadLegacy(f.Directory?.FullName ?? string.Empty, f.Name));
	}

	private bool CheckShouldLoadLegacy(string containingDirectory, string baseFileName)
	{
		string text = _fileSystem.Path.Combine(containingDirectory, baseFileName);
		if (!_fileSystem.Directory.Exists(containingDirectory))
		{
			return false;
		}
		bool flag = _fileSystem.File.Exists(text);
		string text2 = FindMatchingCloudFile(containingDirectory, _fileSystem.Path.GetFileNameWithoutExtension(baseFileName));
		if (flag && text2 != null)
		{
			return !ShouldPreferDocumentFile(text, text2);
		}
		return flag;
	}

	private bool ShouldPreferDocumentFile(string legacyPath, string documentPath)
	{
		DateTime lastWriteTimeUtc = _fileSystem.File.GetLastWriteTimeUtc(legacyPath);
		DateTime lastWriteTimeUtc2 = _fileSystem.File.GetLastWriteTimeUtc(documentPath);
		return lastWriteTimeUtc - lastWriteTimeUtc2 < MINIMUM_FILE_TIMESTAMP_DIFF_TO_CONSIDER_LEGACY;
	}

	private string? FindMatchingCloudFile(string directory, string baseFileName)
	{
		Guid result;
		return _fileSystem.Directory.GetFiles(directory, baseFileName + "-*.proCloud").FirstOrDefault((string f) => Guid.TryParse(_fileSystem.Path.GetFileNameWithoutExtension(f).Substring(baseFileName.Length).TrimStart('-'), out result));
	}
}
