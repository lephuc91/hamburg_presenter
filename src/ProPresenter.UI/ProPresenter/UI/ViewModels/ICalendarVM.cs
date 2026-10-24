using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Cues;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface ICalendarVM : INotifyPropertyChanged
{
	IEnumerable<Event> Events { get; }

	IEnumerable<Event> PastEvents { get; }

	IEnumerable<Event> CurrentEvents { get; }

	IEnumerable<Event> UpcomingEvents { get; }

	bool IsActive { get; set; }

	Event? SelectedEvent { get; set; }

	string EventName { get; set; }

	string Description { get; set; }

	DateTime StartDate { get; set; }

	DateTime EndDate { get; set; }

	bool CanEnd { get; set; }

	EventDay RecurrenceDays { get; set; }

	IAction? EventAction { get; }

	INotifyEnumerableChanged<IPlaylist<ProPresenterCue>> Playlists { get; }

	MacroCollection MacroCollection { get; }

	MacroGroupCollection MacroGroups { get; }

	INotifyEnumerableChanged<ICapturePreset> CapturePresets { get; }

	bool ShowRecurrences { get; set; }

	ICommand<Playlist<ProPresenterCue>> ShowCalendarCommand { get; }

	ICommand TestCommand { get; }

	ICommand GotoCurrentEventCommand { get; }

	ICommand AddEventCommand { get; }

	ICommand RemoveEventCommand { get; }

	ICommand<EventDay> SetDaysCommand { get; }

	ICommand<Playlist<ProPresenterCue>> SelectTargetPlaylistCommand { get; }

	ICommand<(Playlist<ProPresenterCue>? Playlist, ProPresenterCue? Cue)> SelectTargetCueCommand { get; }

	ICommand RemoveTargetCommand { get; }

	ICommand ToggleCalendarEnabledCommand { get; }

	ICommand<ProPresenterMacro> SelectTargetMacroCommand { get; }

	ICommand<CaptureType> SelectCaptureTypeCommand { get; }

	ICommand<CapturePreset> SelectCapturePresetCommand { get; }

	string EventActionName { get; }

	event Action<bool>? CalendarVisibleChanged;
}
