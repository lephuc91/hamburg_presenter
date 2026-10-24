using System.Collections.Generic;
using System.IO;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.MediaLibrary;

public class ImportMediaCommandParameters
{
	public IPlaylist<MediaCue>? TargetPlaylist { get; }

	public IRemoteFile? RemoteFile { get; }

	public IEnumerable<FileInfo>? Files { get; }

	public MediaCue? TargetCue { get; }

	public bool DroppedBefore { get; }

	public ImportMediaCommandParameters(IPlaylist<MediaCue>? targetPlaylist, IRemoteFile remoteFile, MediaCue? targetCue, bool droppedBefore)
	{
		TargetPlaylist = targetPlaylist;
		RemoteFile = remoteFile;
		TargetCue = targetCue;
		DroppedBefore = droppedBefore;
	}

	public ImportMediaCommandParameters(IPlaylist<MediaCue>? targetPlaylist, IEnumerable<FileInfo> files, MediaCue? targetCue, bool droppedBefore)
	{
		TargetPlaylist = targetPlaylist;
		Files = files;
		TargetCue = targetCue;
		DroppedBefore = droppedBefore;
	}
}
