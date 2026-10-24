using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.Serialization.DataManagement;

namespace ProPresenter.DO.Themes;

public class ThemeFolderWatcher : SyncedFolder
{
	private readonly IFileSystem _fileSystem;

	private readonly Action _refresh;

	private readonly Action<string> _addFile;

	private readonly Action<Theme> _remove;

	private readonly Func<IEnumerable<Theme>> _getThemes;

	private readonly Action<string, Theme> _rename;

	private readonly Action<string, string> _renameContainer;

	public ThemeFolderWatcher(IFileWatcherFactory fileWatcherFactory, IFileSystem fileSystem, Action refresh, Action<string> addFile, Action<Theme> remove, Func<IEnumerable<Theme>> getThemes, Action<string, Theme> rename, Action<string, string> renameContainer)
		: base(Path.Combine(CommonPaths.Base, "Themes"), fileWatcherFactory)
	{
		_fileSystem = fileSystem;
		_refresh = refresh;
		_addFile = addFile;
		_remove = remove;
		_getThemes = getThemes;
		_rename = rename;
		_renameContainer = renameContainer;
	}

	protected override void OnTargetFolder_Created(string fullPath)
	{
		if (Path.GetFileName(fullPath) == "Themes")
		{
			_refresh();
		}
	}

	protected override void OnTargetFolder_Deleted(string fullPath)
	{
		ClearAllThemes();
	}

	protected override void OnTargetFolder_Renamed(RenamedEventArgs e)
	{
		if (Path.GetFileName(e.FullPath) == "Themes")
		{
			_refresh();
		}
		else
		{
			ClearAllThemes();
		}
	}

	protected override void OnSubFolder_Created(string fullPath)
	{
		if (fullPath == null || _fileSystem == null)
		{
			return;
		}
		try
		{
			if ((_fileSystem.DirectoryInfo.New(fullPath).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
			{
				string[] array = _fileSystem.Directory.GetFiles(fullPath, "Theme", SearchOption.AllDirectories).ToArray();
				foreach (string obj in array)
				{
					_addFile(obj);
				}
			}
		}
		catch (Exception value)
		{
			Log.Error($"Unable to add theme folder path - {fullPath} with error - {value}");
		}
	}

	protected override void OnSubFolder_Deleted(string fullPath)
	{
		string oldPath = fullPath?.Replace(CommonPaths.Themes, string.Empty);
		(from t in _getThemes()
			where t.Path.IsSubPath(oldPath ?? string.Empty)
			select t).ToArray().ForEach(_remove);
	}

	protected override void OnSubFolder_Renamed(RenamedEventArgs e)
	{
		if (string.IsNullOrEmpty(e.OldFullPath) || string.IsNullOrEmpty(e.FullPath))
		{
			return;
		}
		string oldPath = e.OldFullPath.Replace(CommonPaths.Themes, string.Empty);
		string text = e.FullPath.Replace(CommonPaths.Themes, string.Empty);
		if (string.IsNullOrEmpty(oldPath) || string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (Theme item in from t in _getThemes()
			where t.Path.IsSubPath(oldPath)
			select t)
		{
			string text2 = item.Path.Replace(oldPath, text);
			string fileName = Path.GetFileName(text2);
			RenameTheme(item, fileName, text2);
		}
		_renameContainer(oldPath, text);
	}

	private void RenameTheme(Theme theme, string newName, string newPath)
	{
		if (theme != null)
		{
			theme.Name = newName;
			theme.UpdatePath(newPath);
			string text = Path.Combine(newPath, "Theme");
			text = text.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			_rename(text, theme);
		}
	}

	private void ClearAllThemes()
	{
		_getThemes().ToArray().ForEach(_remove);
	}
}
