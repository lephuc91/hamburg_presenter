using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Cues;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Calendar;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Calendar;

public class CalendarVM : LinkedNotifyPropertyChangedBase, ICalendarVM, INotifyPropertyChanged
{
	private readonly IEventCalendar _calendar;

	private readonly ICaptureService _captureService;

	private readonly ICalendarPrompt _prompt;

	private readonly Lazy<CalendarWindow> _calendarWindow;

	private readonly IProPresenterResourceService _resources;

	private bool _isActive;

	private Event? _selectedEvent;

	private bool _showRecurrences;

	public IEnumerable<Event> Events => from g in _calendar
		select g.Main into e
		orderby e.TriggerDate
		select e;

	public IEnumerable<Event> PastEvents => _calendar.PastEvents;

	public IEnumerable<Event> CurrentEvents => _calendar.CurrentEvents;

	public IEnumerable<Event> UpcomingEvents => _calendar.UpcomingEvents;

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			SetValue("IsActive", ref _isActive, value, delegate(bool o, bool n)
			{
				_calendar.IsActive = n;
			});
		}
	}

	public Event? SelectedEvent
	{
		get
		{
			return _selectedEvent;
		}
		set
		{
			SetValue<Event>("SelectedEvent", ref _selectedEvent, value, delegate(Event o, Event n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("EventName");
				OnPropertyChanged("Description");
				OnPropertyChanged("StartDate");
				OnPropertyChanged("EndDate");
				OnPropertyChanged("CanEnd");
				OnPropertyChanged("RecurrenceDays");
				OnPropertyChanged("EventAction");
				OnPropertyChanged("EventActionName");
			});
		}
	}

	public string EventName
	{
		get
		{
			return SelectedEvent?.Name ?? string.Empty;
		}
		set
		{
			if (ShouldUpdateRecurrence() && EventName != value)
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				UpdateRecurringEvent(value, Description, StartDate, SelectedEvent.EventAction);
			}
			else if (SelectedEvent != null)
			{
				EventCollection? eventCollection = _calendar.FindGroup(SelectedEvent);
				eventCollection.ThrowWhenNull("group");
				eventCollection.Main.Name = value;
			}
		}
	}

	public string Description
	{
		get
		{
			return SelectedEvent?.Description ?? string.Empty;
		}
		set
		{
			if (ShouldUpdateRecurrence() && Description != value)
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				UpdateRecurringEvent(EventName, value, StartDate, SelectedEvent.EventAction);
			}
			else if (SelectedEvent != null)
			{
				EventCollection? eventCollection = _calendar.FindGroup(SelectedEvent);
				eventCollection.ThrowWhenNull("group");
				eventCollection.Main.Description = value;
			}
		}
	}

	public DateTime StartDate
	{
		get
		{
			return SelectedEvent?.TriggerDate ?? default(DateTime);
		}
		set
		{
			if (ShouldUpdateRecurrence() && StartDate != value)
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				UpdateRecurringEvent(EventName, Description, value, SelectedEvent.EventAction);
			}
			else if (SelectedEvent != null)
			{
				Event @event = _calendar.FindGroup(SelectedEvent)?.Main;
				@event.ThrowWhenNull("selectedEvent");
				@event.StartDate = value;
				EndDate = ((EndDate < value) ? value : EndDate);
				RecurrenceDays = @event.RecurrenceDays;
			}
		}
	}

	public DateTime EndDate
	{
		get
		{
			return SelectedEvent?.EndDate ?? StartDate;
		}
		set
		{
			if (ShouldUpdateRecurrence() && EndDate != value)
			{
				UpdateRecurringEventRepeatType(RecurrenceDays, value, CanEnd);
			}
			else if (SelectedEvent != null && CanEnd)
			{
				EventCollection? eventCollection = _calendar.FindGroup(SelectedEvent);
				eventCollection.ThrowWhenNull("group");
				eventCollection.Main.EndDate = value;
			}
		}
	}

	public bool CanEnd
	{
		get
		{
			return SelectedEvent?.EndDate.HasValue ?? false;
		}
		set
		{
			if (ShouldUpdateRecurrence() && CanEnd != value)
			{
				UpdateRecurringEventRepeatType(RecurrenceDays, SelectedEvent?.EndDate, value);
			}
			else if (SelectedEvent != null)
			{
				EventCollection? eventCollection = _calendar.FindGroup(SelectedEvent);
				eventCollection.ThrowWhenNull("group");
				eventCollection.Main.EndDate = (value ? new DateTime?(EndDate) : ((DateTime?)null));
			}
		}
	}

	public EventDay RecurrenceDays
	{
		get
		{
			return SelectedEvent?.RecurrenceDays ?? EventDay.Unknown;
		}
		set
		{
			if (ShouldUpdateRecurrence() && RecurrenceDays != value)
			{
				UpdateRecurringEventRepeatType(value, SelectedEvent?.EndDate, CanEnd);
			}
			else if (SelectedEvent != null)
			{
				EventCollection? eventCollection = _calendar.FindGroup(SelectedEvent);
				eventCollection.ThrowWhenNull("group");
				eventCollection.Main.RecurrenceDays = value;
			}
		}
	}

	public IAction? EventAction
	{
		get
		{
			return SelectedEvent?.EventAction;
		}
		private set
		{
			if (ShouldUpdateRecurrence())
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				UpdateRecurringEvent(EventName, Description, SelectedEvent.TriggerDate, value);
			}
			else if (SelectedEvent != null)
			{
				(_calendar.FindGroup(SelectedEvent)?.Main)?.SetEventAction(value);
			}
			OnPropertyChanged("EventAction");
			OnPropertyChanged("EventActionName");
		}
	}

	public string EventActionName => GetEventActionName();

	public bool ShowRecurrences
	{
		get
		{
			return _showRecurrences;
		}
		set
		{
			SetValue("ShowRecurrences", ref _showRecurrences, value, delegate(bool o, bool n)
			{
				if (n)
				{
					SelectedEvent = PastEvents.FirstOrDefault() ?? CurrentEvents.FirstOrDefault() ?? UpcomingEvents.FirstOrDefault();
				}
				else if (SelectedEvent != null)
				{
					SelectedEvent = _calendar.FindGroup(SelectedEvent)?.Main;
				}
			});
		}
	}

	public INotifyEnumerableChanged<IPlaylist<ProPresenterCue>> Playlists => _resources.LibraryPlaylists;

	public MacroCollection MacroCollection => _resources.Macros;

	public MacroGroupCollection MacroGroups => _resources.MacroGroups;

	public INotifyEnumerableChanged<ICapturePreset> CapturePresets => _captureService.CaptureSettings.Presets;

	public ICommand<Playlist<ProPresenterCue>> ShowCalendarCommand => new RelayCommand<Playlist<ProPresenterCue>>(OnShowCalendarCommand);

	public ICommand TestCommand => new RelayCommand(OnTestCommand);

	public ICommand GotoCurrentEventCommand => new RelayCommand(OnGoToCurrentEventCommand, () => Events.Any() && _calendar.ActiveEvent != null);

	public ICommand AddEventCommand => new RelayCommand(OnAddEventCommand);

	public ICommand RemoveEventCommand => new RelayCommand(OnRemoveEventCommand, () => SelectedEvent != null);

	public ICommand<EventDay> SetDaysCommand => new RelayCommand<EventDay>(OnSetDayCommand);

	public ICommand<Playlist<ProPresenterCue>> SelectTargetPlaylistCommand => new RelayCommand<Playlist<ProPresenterCue>>(OnSelectTargetPlaylistCommand);

	public ICommand<(Playlist<ProPresenterCue>? Playlist, ProPresenterCue? Cue)> SelectTargetCueCommand => new RelayCommand<(Playlist<ProPresenterCue>, ProPresenterCue)>(OnSelectTargetCueCommand);

	public ICommand<CaptureType> SelectCaptureTypeCommand => new RelayCommand<CaptureType>(SelectCaptureTypeCommandExecute);

	public ICommand<CapturePreset> SelectCapturePresetCommand => new RelayCommand<CapturePreset>(SelectCapturePresetCommandExecuted);

	public ICommand RemoveTargetCommand => new RelayCommand(OnRemoveTargetCommand);

	public ICommand ToggleCalendarEnabledCommand => new RelayCommand(delegate
	{
		IsActive = !IsActive;
	});

	public ICommand<ProPresenterMacro> SelectTargetMacroCommand => new RelayCommand<ProPresenterMacro>(OnSelectTargetMacroCommand);

	public event Action<bool>? CalendarVisibleChanged;

	private string GetEventActionName()
	{
		IAction eventAction = EventAction;
		LibraryPlaylistAction playlistAction = eventAction as LibraryPlaylistAction;
		if (playlistAction != null)
		{
			string text = playlistAction.PlaylistItemName ?? playlistAction.Name;
			if (string.IsNullOrWhiteSpace(text))
			{
				Playlist<ProPresenterCue> playlist = _resources.LibraryPlaylists?.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == playlistAction.PlaylistID)?.FirstOrDefault() as Playlist<ProPresenterCue>;
				ProPresenterCue proPresenterCue = playlist?.FirstOrDefault((ProPresenterCue c) => c.ID == playlistAction.PlaylistItemID);
				if ((proPresenterCue?.Name).NullableIsNullOrWhiteSpace())
				{
					if ((playlist?.Name).NullableIsNullOrWhiteSpace())
					{
						return string.Empty;
					}
					return playlist.Name;
				}
				return proPresenterCue.Name;
			}
			return text;
		}
		return EventAction?.Name ?? string.Empty;
	}

	public CalendarVM(IProPresenterResourceService resources, ICaptureService captureService, ICalendarPrompt prompt)
	{
		_resources = resources;
		_calendar = _resources.Calendar;
		_captureService = captureService;
		IsActive = _calendar.IsActive;
		SelectedEvent = _calendar.FirstOrDefault()?.Main;
		_prompt = prompt;
		_calendarWindow = new Lazy<CalendarWindow>(GenerateCalendarWindow);
		HookupLinkedProperties();
		if (_resources.LibraryPlaylists != null)
		{
			_resources.LibraryPlaylists.CollectionModified += delegate
			{
				OnPropertyChanged("Playlists");
			};
			InitializePlaylist();
		}
	}

	private void InitializePlaylist()
	{
		foreach (Event calendarEvent in _calendar.Select((EventCollection c) => c.Main))
		{
			IAction eventAction = calendarEvent.EventAction;
			LibraryPlaylistAction playlistAction = eventAction as LibraryPlaylistAction;
			if (playlistAction == null)
			{
				continue;
			}
			foreach (Playlist<ProPresenterCue> item in from p in _resources.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == playlistAction.PlaylistID).OfType<Playlist<ProPresenterCue>>()
				where !p.Events.Contains(calendarEvent)
				select p)
			{
				item.Events.Add(calendarEvent);
			}
		}
	}

	private void HookupLinkedProperties()
	{
		LinkProperties(new string[3] { "PastEvents", "CurrentEvents", "UpcomingEvents" }, new string[4] { "PastEvents", "CurrentEvents", "UpcomingEvents", "Events" });
		LinkProperties("Name", "EventName");
		LinkProperties("Description", "Description");
		LinkProperties(new string[2] { "StartDate", "TriggerDate" }, "StartDate");
		LinkProperties("EndDate", new string[2] { "EndDate", "CanEnd" });
		LinkProperties("RecurrenceDays", "RecurrenceDays");
		LinkProperties("EventAction", "EventAction");
		_calendar.PropertyChanged += base.RaiseLinkedValues;
	}

	private CalendarWindow GenerateCalendarWindow()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		CalendarWindow calendarWindow = new CalendarWindow().WithDataContext(this);
		calendarWindow.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate(object s, DependencyPropertyChangedEventArgs e)
		{
			this.CalendarVisibleChanged?.Invoke((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		};
		return calendarWindow;
	}

	private void OnShowCalendarCommand(Playlist<ProPresenterCue> playlist)
	{
		if (playlist != null)
		{
			SelectedEvent = Events.FirstOrDefault((Event e) => e.EventAction is LibraryPlaylistAction libraryPlaylistAction && libraryPlaylistAction.PlaylistID == playlist.ID);
		}
		_calendarWindow.Value.Visibility = (_calendarWindow.Value.IsVisible ? Visibility.Collapsed : Visibility.Visible);
	}

	private void OnTestCommand()
	{
		SelectedEvent.ThrowWhenNull("SelectedEvent");
		_calendar.ExecuteEvent(SelectedEvent);
	}

	private void OnGoToCurrentEventCommand()
	{
		SelectedEvent = _calendar.ActiveEvent;
	}

	private void OnAddEventCommand()
	{
		Event @event = new Event
		{
			StartDate = GetNextHour(_calendar.LastOrDefault()?.Main.StartDate ?? DateTime.Now),
			EndDate = null
		};
		_calendar.AddEvent(@event);
		SelectedEvent = @event;
	}

	private static DateTime GetNextHour(DateTime date)
	{
		return date.AddHours(1.0).TruncateSeconds().TruncateMilliseconds();
	}

	private void OnRemoveEventCommand()
	{
		SelectedEvent.ThrowWhenNull("SelectedEvent");
		EventCollection eventCollection = _calendar.FindGroup(SelectedEvent);
		IAction action = eventCollection?.Main.EventAction;
		bool removeAllOccurrences;
		if (!ShouldUpdateRecurrence())
		{
			Event selectedEvent = _calendar.GetPrevious(eventCollection)?.Main ?? _calendar.GetNext(eventCollection)?.Main;
			_calendar.RemoveEvent(eventCollection);
			SelectedEvent = selectedEvent;
		}
		else if (_prompt.ConfirmRemoveEvent(out removeAllOccurrences))
		{
			Event selectedEvent2 = ((!removeAllOccurrences) ? eventCollection?.GetPrevious<Event>(SelectedEvent) : (_calendar.GetPrevious(eventCollection)?.Main ?? _calendar.GetNext(eventCollection)?.Main));
			_calendar.RemoveRecurringEvent(SelectedEvent, removeAllOccurrences);
			SelectedEvent = selectedEvent2;
		}
		RemovePlaylistEvent(eventCollection?.Main, action);
	}

	private void RemovePlaylistEvent(Event? calendarEvent, IAction? action)
	{
		if (calendarEvent == null || action == null)
		{
			return;
		}
		LibraryPlaylistAction playlistAction = action as LibraryPlaylistAction;
		if (playlistAction == null)
		{
			return;
		}
		foreach (Playlist<ProPresenterCue> item in from p in _resources.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == playlistAction.PlaylistID).OfType<Playlist<ProPresenterCue>>()
			where p.Events.Contains(calendarEvent)
			select p)
		{
			item.Events.Remove(calendarEvent);
		}
	}

	private void OnSetDayCommand(EventDay day)
	{
		if (RecurrenceDays.HasFlag(day))
		{
			RecurrenceDays &= ~day;
		}
		else
		{
			RecurrenceDays |= day;
		}
		if (RecurrenceDays == EventDay.Unknown)
		{
			CanEnd = false;
		}
	}

	private void OnSelectTargetPlaylistCommand(IPlaylist<ProPresenterCue> playlist)
	{
		if (playlist != null)
		{
			ClearPlaylistEvent();
			EventAction = playlist.ToAction();
			if (playlist is Playlist<ProPresenterCue> playlist2)
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				playlist2.Events.Add(SelectedEvent);
			}
		}
	}

	private void OnSelectTargetCueCommand((Playlist<ProPresenterCue>? Playlist, ProPresenterCue? Cue) param)
	{
		if (param.Playlist != null && param.Cue != null)
		{
			ClearPlaylistEvent();
			if (param.Playlist.ToAction() is LibraryPlaylistAction libraryPlaylistAction)
			{
				libraryPlaylistAction.SetPlaylistItem(param.Cue.ID, param.Cue.Name);
				EventAction = libraryPlaylistAction;
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				param.Playlist.Events.Add(SelectedEvent);
			}
		}
	}

	private void OnSelectTargetMacroCommand(ProPresenterMacro macro)
	{
		EventAction = macro.ToAction();
		ClearPlaylistEvent();
	}

	private void SelectCaptureTypeCommandExecute(CaptureType type)
	{
		EventAction = type.ToAction();
		ClearPlaylistEvent();
	}

	private void SelectCapturePresetCommandExecuted(CapturePreset preset)
	{
		EventAction = preset.ToAction();
		ClearPlaylistEvent();
	}

	private void OnRemoveTargetCommand()
	{
		EventAction = null;
		ClearPlaylistEvent();
	}

	private void ClearPlaylistEvent()
	{
		if (_resources.LibraryPlaylists == null)
		{
			return;
		}
		foreach (IPlaylist<ProPresenterCue> playlist2 in _resources.LibraryPlaylists.GetPlaylists())
		{
			if (playlist2 is Playlist<ProPresenterCue> playlist)
			{
				SelectedEvent.ThrowWhenNull("SelectedEvent");
				playlist.Events.Remove(SelectedEvent);
			}
		}
	}

	private bool IsFirstUpcomingEvent()
	{
		if (SelectedEvent != null)
		{
			return _calendar.FindGroup(SelectedEvent)?.FirstOrDefault() == SelectedEvent;
		}
		return false;
	}

	private bool ShouldUpdateRecurrence()
	{
		if (ShowRecurrences && SelectedEvent != null)
		{
			return !IsFirstUpcomingEvent();
		}
		return false;
	}

	private void UpdateRecurringEvent(string name, string description, DateTime date, IAction? eventAction)
	{
		if (_prompt.ConfirmUpdateEvent(out var updateFutureEvents))
		{
			Event @event = updateEvent();
			if (@event != null)
			{
				SelectedEvent = @event;
			}
		}
		Event updateEvent()
		{
			SelectedEvent.ThrowWhenNull("SelectedEvent");
			return _calendar.UpdateRecurringEvent(SelectedEvent, name, description, date, eventAction?.Clone(), updateFutureEvents);
		}
	}

	private void UpdateRecurringEventRepeatType(EventDay day, DateTime? newEndDate, bool canEnd)
	{
		if (_prompt.ConfirmUpdateEventType())
		{
			Event @event = updateEventType();
			if (@event != null)
			{
				SelectedEvent = @event;
			}
		}
		Event updateEventType()
		{
			SelectedEvent.ThrowWhenNull("SelectedEvent");
			return _calendar.UpdateRecurringEventRepeatType(SelectedEvent, day, newEndDate, canEnd);
		}
	}
}
