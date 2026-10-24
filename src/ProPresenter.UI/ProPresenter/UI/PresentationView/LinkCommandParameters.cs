using System.IO;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.SongSelect;

namespace ProPresenter.UI.PresentationView;

public class LinkCommandParameters
{
	public ProPresenterCue? TargetCue { get; }

	public IPresentation? Presentation { get; }

	public MediaBase? Media { get; }

	public FileInfo[]? Files { get; }

	public IRemoteFile? RemoteFile { get; }

	public ISongSelectSearchResult? SongSelectResult { get; }

	public IMultiTracksSearchResult? MultiTracksSearchResult { get; }

	public LinkCommandParameters(ProPresenterCue? targetCue)
	{
		TargetCue = targetCue;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, IPresentation? presentation)
	{
		TargetCue = targetCue;
		Presentation = presentation;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, MediaBase? media)
	{
		TargetCue = targetCue;
		Media = media;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, FileInfo[]? files)
	{
		TargetCue = targetCue;
		Files = files;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, IRemoteFile? remoteFile)
	{
		TargetCue = targetCue;
		RemoteFile = remoteFile;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, ISongSelectSearchResult? songSelectResult)
	{
		TargetCue = targetCue;
		SongSelectResult = songSelectResult;
	}

	public LinkCommandParameters(ProPresenterCue? targetCue, IMultiTracksSearchResult? multiTracks)
	{
		TargetCue = targetCue;
		MultiTracksSearchResult = multiTracks;
	}
}
