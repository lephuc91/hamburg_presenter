using System;
using System.Collections.Generic;
using System.IO;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Sync.Local;

public class SyncDataProvider : ISyncDataProvider
{
	private readonly IFileProvider _fileProvider;

	public SyncDataProvider(IFileProvider fileProvider)
	{
		_fileProvider = fileProvider;
	}

	public IReadOnlyCollection<ISyncData> GetSyncData(RelativePath folder, FileAccess fileAccess)
	{
		return GetSyncData(folder, ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeLibraryDoc, ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludePlaylists, ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeMedia, ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeTemplates, ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeUserData, fileAccess);
	}

	public IReadOnlyCollection<ISyncData> GetSyncData(RelativePath folder, bool includeLibrary, bool includePlaylists, bool includeMedia, bool includeThemes, bool includeConfiguration, FileAccess fileAccess)
	{
		if (!folder.IsValid)
		{
			return (IReadOnlyCollection<ISyncData>)(object)Array.Empty<ISyncData>();
		}
		List<ISyncData> syncData = new List<ISyncData>();
		if (includeLibrary)
		{
			addFiles(Path.Combine(folder, "Libraries"), SyncFileType.Library, (string f) => f.IsProPresentationFile() || f.IsLibraryFile());
		}
		if (includePlaylists)
		{
			addFiles(Path.Combine(folder, "Playlists"), SyncFileType.Playlist, (string f) => f.IsPlaylistFile());
		}
		if (includeMedia)
		{
			addFiles(Path.Combine(folder, "Media"), SyncFileType.Media, (string f) => f.IsMediaFile());
		}
		if (includeThemes)
		{
			addFiles(Path.Combine(folder, "Themes"), SyncFileType.Theme, (string f) => f.IsThemeFile() || f.IsMediaFile());
		}
		if (includeConfiguration)
		{
			addFiles(Path.Combine(folder, "Configuration"), SyncFileType.Configuration, (string f) => f.IsConfigurationFile());
		}
		return syncData;
		void addFiles(string path, SyncFileType fileType, Predicate<string> isSupported)
		{
			foreach (FileInfo file in _fileProvider.GetFiles(path))
			{
				string fullName = file.FullName;
				FileAccess fileAccess2 = fileAccess;
				if ((bool)FileHelper.WaitForFileAccess(fullName, enforceFileExists: false, null, fileAccess2) && isSupported(file.FullName))
				{
					if (file.Exists)
					{
						if (!file.Attributes.HasFlag(FileAttributes.Hidden))
						{
							syncData.Add(new SyncFileData(file.FullName, fileType));
						}
					}
					else
					{
						syncData.Add(new SyncFileData(file.FullName, fileType));
					}
				}
			}
		}
	}
}
