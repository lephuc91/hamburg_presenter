using System.Collections.Generic;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.LibraryView;

public class DropFilesCommandParameters
{
	public IRemoteFile? RemoteFile { get; }

	public IEnumerable<string>? Filenames { get; }

	public int DropIndex { get; }

	public IPlaylist<ProPresenterCue>? TargetPlaylist { get; }

	public ILibrary? TargetLibrary { get; }

	public DropFilesCommandParameters(IRemoteFile remoteFile, int dropIndex, IPlaylist<ProPresenterCue>? targetPlaylist = null, ILibrary? targetLibrary = null)
	{
		RemoteFile = remoteFile;
		DropIndex = dropIndex;
		TargetPlaylist = targetPlaylist;
		TargetLibrary = targetLibrary;
	}

	public DropFilesCommandParameters(IEnumerable<string> filenames, int dropIndex, IPlaylist<ProPresenterCue>? targetPlaylist = null, ILibrary? targetLibrary = null)
	{
		Filenames = filenames;
		DropIndex = dropIndex;
		TargetPlaylist = targetPlaylist;
		TargetLibrary = targetLibrary;
	}
}
