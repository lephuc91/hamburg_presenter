using System;

namespace ProPresenter.DO.Themes;

public class ThemeFolderWatcherEventArgs : EventArgs
{
	public string FolderPath { get; }

	public ThemeFolderWatcherEventArgs(string folderPath)
	{
		FolderPath = folderPath;
	}
}
