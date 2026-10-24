using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller;

public class SlideTriggerOptions
{
	public bool OverrideEnable { get; }

	public bool SuppressGotoNext { get; }

	public BiblePresentation? BiblePresentation { get; }

	public TimelineTriggerOptions? Timeline { get; }

	public ProPresenterCue? Cue { get; }

	public Playlist<ProPresenterCue>? Playlist { get; }

	public OutputDestination? Destination => (Cue as IDocumentCue)?.DocumentAction?.Destination;

	public SlideTriggerOptions(bool overrideEnable = false, bool suppressGoToNext = false, BiblePresentation? biblePresentation = null, TimelineTriggerOptions? timeline = null, ProPresenterCue? cue = null, Playlist<ProPresenterCue>? playlist = null)
	{
		OverrideEnable = overrideEnable;
		SuppressGotoNext = suppressGoToNext;
		BiblePresentation = biblePresentation;
		Timeline = timeline;
		Cue = cue;
		Playlist = playlist;
	}
}
