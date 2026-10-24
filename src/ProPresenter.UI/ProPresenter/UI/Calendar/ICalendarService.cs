using System;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Calendar;

public interface ICalendarService
{
	public enum ActionType
	{
		Playlist,
		Presentation,
		Other
	}

	ProPresenterCue? TriggeredCue { get; }

	Playlist<ProPresenterCue>? TriggeredPlaylist { get; }

	event EventHandler<CalendarCueTriggeredEventArgs>? CueTriggered;

	ActionType GetActionType(LibraryPlaylistAction action);
}
