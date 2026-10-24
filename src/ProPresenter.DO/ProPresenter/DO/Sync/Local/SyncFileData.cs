using System.ComponentModel;
using System.IO;
using Pro.Common.Components;
using Pro.Common.FileSystem;

namespace ProPresenter.DO.Sync.Local;

public class SyncFileData : LinkedNotifyPropertyChangedBase, ISyncData, INotifyPropertyChanged
{
	public string Name { get; }

	public long Size { get; }

	public long DateModified { get; }

	public SyncFileType FileType { get; }

	public string FullPath { get; }

	public bool CanModify { get; }

	public bool SkipFileCheck { get; }

	public SyncFileData(FileInfo fileInfo, SyncFileType fileType)
	{
		Name = fileInfo.Name;
		Size = (fileInfo.Exists ? fileInfo.Length : 0);
		DateModified = fileInfo.FileModifiedTimestamp().GetValueOrDefault();
		FullPath = fileInfo.FullName;
		FileType = fileType;
		CanModify = fileType != SyncFileType.Configuration;
		SkipFileCheck = fileType == SyncFileType.Playlist;
	}

	public SyncFileData(string file, SyncFileType fileType)
		: this(new FileInfo(file), fileType)
	{
	}
}
