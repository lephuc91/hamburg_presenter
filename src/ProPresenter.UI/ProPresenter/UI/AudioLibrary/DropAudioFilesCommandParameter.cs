using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.AudioLibrary;

public class DropAudioFilesCommandParameter
{
	public IRemoteFile? RemoteFile { get; }

	public IEnumerable<string> Filenames { get; }

	public AudioPlaylist? TargetPlaylist { get; }

	public int DropIndex { get; }

	public DropAudioFilesCommandParameter(IRemoteFile remoteFile, AudioPlaylist? targetPlaylist, int dropIndex)
	{
		RemoteFile = remoteFile;
		TargetPlaylist = targetPlaylist;
		DropIndex = dropIndex;
		Filenames = Enumerable.Empty<string>();
	}

	public DropAudioFilesCommandParameter(IEnumerable<string> filenames, AudioPlaylist? targetPlaylist, int dropIndex)
	{
		Filenames = filenames;
		TargetPlaylist = targetPlaylist;
		DropIndex = dropIndex;
	}
}
