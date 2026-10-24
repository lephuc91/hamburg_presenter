using System;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Calendar;

public class CalendarCueTriggeredEventArgs : EventArgs
{
	public Playlist<ProPresenterCue> Playlist { get; }

	public ProPresenterCue Cue { get; }

	public CalendarCueTriggeredEventArgs(Playlist<ProPresenterCue> playlist, ProPresenterCue cue)
	{
		Playlist = playlist;
		Cue = cue;
	}
}
