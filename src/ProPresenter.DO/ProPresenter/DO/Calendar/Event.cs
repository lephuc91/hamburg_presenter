using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Disposables;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Calendar;

public class Event : NotifyPropertyChangedBase, ICloneable<Event>
{
	private readonly ActionCollection _actions = new ActionCollection();

	private string _name = LocalizedStrings.Get("CALENDAR_VIEW_NEW_EVENT_name");

	private string _description = string.Empty;

	private DateTime _triggerDate = DateTime.Now;

	private DateTime _startDate = DateTime.Now;

	private DateTime? _endDate;

	private EventDay _recurrenceDays;

	private Playlist<ProPresenterCue>? _targetPlaylist;

	private ProPresenterCue? _targetCue;

	private ProPresenterMacro? _targetMacro;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnDataModified);
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue("Description", ref _description, value, OnDataModified);
		}
	}

	public DateTime TriggerDate
	{
		get
		{
			return _triggerDate;
		}
		set
		{
			SetValue("TriggerDate", ref _triggerDate, value);
		}
	}

	public DateTime StartDate
	{
		get
		{
			return _startDate;
		}
		set
		{
			SetValue("StartDate", ref _startDate, value, delegate(DateTime o, DateTime n)
			{
				TriggerDate = n;
				if (RecurrenceDays != 0 && !RecurrenceDays.HasFlag(n.DayOfWeek.ToEventDay()))
				{
					int num = n.DayOfWeek - o.DayOfWeek;
					if (num != 0)
					{
						bool flag = num > 0;
						int num2 = (int)RecurrenceDays;
						for (int i = 0; i < Math.Abs(num); i++)
						{
							if (flag)
							{
								num2 <<= 1;
								num2 = (num2 & 0x7F) | ((num2 & 0x80) >> 7);
							}
							else
							{
								int num3 = (num2 & 1) << 6;
								num2 >>= 1;
								num2 |= num3;
							}
						}
						RecurrenceDays = (EventDay)num2;
					}
				}
				OnDataModified();
				OnRecurrencesUpdated();
			});
		}
	}

	public DateTime? EndDate
	{
		get
		{
			return _endDate;
		}
		set
		{
			SetValue("EndDate", ref _endDate, value, (System.Action)delegate
			{
				OnDataModified();
				OnRecurrencesUpdated();
			}, (Predicate<DateTime?>?)null, referenceComparison: false);
		}
	}

	public EventDay RecurrenceDays
	{
		get
		{
			return _recurrenceDays;
		}
		set
		{
			SetValue("RecurrenceDays", ref _recurrenceDays, value, (System.Action)delegate
			{
				DayOfWeek[] recurrenceDays = GetRecurrenceDays();
				DayOfWeek dayOfWeek = StartDate.DayOfWeek;
				if (recurrenceDays.Any() && !recurrenceDays.Contains(dayOfWeek))
				{
					int num = recurrenceDays.FirstOrDefault() - dayOfWeek;
					_startDate = StartDate.AddDays(((num < 0) ? 7 : 0) + num);
					_triggerDate = _startDate;
					if (EndDate.HasValue && EndDate < StartDate)
					{
						_endDate = StartDate;
					}
					OnPropertyChanged("StartDate");
					OnPropertyChanged("TriggerDate");
					OnPropertyChanged("EndDate");
				}
				OnDataModified();
				OnRecurrencesUpdated();
			}, (Predicate<EventDay>?)null, referenceComparison: false);
		}
	}

	public ObservableCollection<DateTime> RecurrenceExcludedDates { get; } = new ObservableCollection<DateTime>();

	public Pro.DO.Triggering.IAction? EventAction => Actions.FirstOrDefault();

	private INotifyEnumerableChanged<Pro.DO.Triggering.IAction> Actions => _actions;

	public event System.Action? DataModified;

	public event System.Action? RecurrencesUpdated;

	public static ObjectBinder<Event, ICalendar.Types.IEvent> CreateBinder(IUiScheduler uiScheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, Event left, ICalendar.Types.IEvent right)
	{
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> objectBinder = ActionCollection.CreateBinder(uiScheduler, entityFactory, actionBinderFactory, left._actions, right.Actions);
		return new ObjectBinder<Event, ICalendar.Types.IEvent>(left, right).Bind((Event m) => m.WhenPropertyChanges("ID"), (ICalendar.Types.IEvent e) => e.Uuid.WhenValueChanges, delegate(Event m, ICalendar.Types.IEvent e)
		{
			e.Uuid.Set(m.ID);
		}, delegate(ICalendar.Types.IEvent e, Event m)
		{
			m.ID = e.Uuid.Value;
		}).Bind((Event m) => m.WhenPropertyChanges("Name"), (ICalendar.Types.IEvent e) => e.Name.WhenValueChanges, delegate(Event m, ICalendar.Types.IEvent e)
		{
			e.Name.Set(m.Name);
		}, delegate(ICalendar.Types.IEvent e, Event m)
		{
			m.Name = e.Name.Value;
		}).Bind((Event m) => m.WhenPropertyChanges("Description"), (ICalendar.Types.IEvent e) => e.Description.WhenValueChanges, delegate(Event m, ICalendar.Types.IEvent e)
		{
			e.Description.Set(m.Description);
		}, delegate(ICalendar.Types.IEvent e, Event m)
		{
			m.Description = e.Description.Value ?? string.Empty;
		})
			.Bind((Event m) => m.WhenPropertyChanges("StartDate"), (ICalendar.Types.IEvent e) => e.Date.WhenValueChanges, delegate(Event m, ICalendar.Types.IEvent e)
			{
				e.Date.Set(m.StartDate.ToTimestamp());
			}, delegate(ICalendar.Types.IEvent e, Event m)
			{
				m.StartDate = e.Date.ToLocalDateTime();
			})
			.Bind((Event m) => m.WhenPropertyChanges("EndDate"), (ICalendar.Types.IEvent e) => e.RecurrenceLimitDate.WhenValueChanges, delegate(Event m, ICalendar.Types.IEvent e)
			{
				e.RecurrenceLimitDate.Set(m.EndDate?.ToTimestamp());
			}, delegate(ICalendar.Types.IEvent e, Event m)
			{
				m.EndDate = e.RecurrenceLimitDate.Value?.ToLocalDateTime();
			})
			.Bind((Event m) => m.WhenPropertyChanges("RecurrenceDays"), (ICalendar.Types.IEvent e) => e.RecurrenceDays.WhenCollectionChanges, delegate(Event m, ICalendar.Types.IEvent e)
			{
				e.RecurrenceDays.Reset(m.RecurrenceDays.ToEntityRecurrenceDays());
			}, delegate(ICalendar.Types.IEvent e, Event m)
			{
				m.RecurrenceDays = e.RecurrenceDays.Items.ToEventDay();
			})
			.Bind((Event m) => m.RecurrenceExcludedDates.WhenCollectionChanges(), (ICalendar.Types.IEvent e) => e.RecurrenceExcludedDates.WhenCollectionChanges, delegate(Event m, ICalendar.Types.IEvent e)
			{
				e.RecurrenceExcludedDates.Reset(m.RecurrenceExcludedDates.Select((DateTime x) => x.ToTimestamp()));
			}, delegate(ICalendar.Types.IEvent e, Event m)
			{
				m.RecurrenceExcludedDates.Clear();
				m.RecurrenceExcludedDates.AddRange(e.RecurrenceExcludedDates.Items.Select((Pro.Entity.Timestamp x) => x.ToLocalDateTime()));
				m.OnPropertyChanged("RecurrenceExcludedDates");
			}, null, uiScheduler.Scheduler)
			.DoOnInitializeLeftFromRight(objectBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(objectBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(new CompositeDisposable { objectBinder });
	}

	public Event()
	{
		RecurrenceExcludedDates.CollectionChanged += delegate
		{
			OnDataModified();
		};
		_actions.CollectionChanged += Actions_CollectionChanged;
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs? e)
	{
		OnPropertyChanged("EventAction");
		OnDataModified();
		OnRecurrencesUpdated();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void OnRecurrencesUpdated()
	{
		this.RecurrencesUpdated?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.Calendar.Types.Event Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Calendar.Types.Event @event = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event
		{
			Uuid = ID.ToUUID(),
			Name = Name,
			Description = Description,
			Date = StartDate.ToTimeStamp(),
			RecurrenceLimitDate = EndDate?.ToTimeStamp(),
			Action = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action()
		};
		@event.RecurrenceDays.AddRange(RecurrenceDays.ToProtoRecurrenceDays());
		@event.RecurrenceExcludedDates.AddRange(RecurrenceExcludedDates.Select((DateTime d) => d.ToTimeStamp()));
		@event.Actions.AddRange(Actions.Select((Pro.DO.Triggering.IAction a) => a.Serialize()));
		Pro.DO.Triggering.IAction eventAction = EventAction;
		if (!(eventAction is MacroAction macroAction))
		{
			if (eventAction is LibraryPlaylistAction libraryPlaylistAction)
			{
				@event.Action = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action
				{
					Playlist = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action.Types.Playlist
					{
						PlaylistUuid = libraryPlaylistAction.PlaylistID.ToUUID(),
						PlaylistItemUuid = libraryPlaylistAction.PlaylistItemID.ToUUID()
					}
				};
			}
		}
		else
		{
			@event.Action = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action
			{
				Macro = new Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action.Types.Macro
				{
					Identification = new CollectionElementType
					{
						ParameterUuid = macroAction.MacroID.ToUUID(),
						ParameterName = (macroAction.MacroName ?? string.Empty),
						ParentCollection = new CollectionElementType
						{
							ParameterUuid = macroAction.MacroParentCollectionID.ToUUID(),
							ParameterName = macroAction.MacroParentCollectionName
						}
					}
				}
			};
		}
		return @event;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Calendar.Types.Event calenderEvent)
	{
		ID = calenderEvent.Uuid.ToGuid();
		Name = calenderEvent.Name;
		Description = calenderEvent.Description;
		StartDate = calenderEvent.Date.ToDateTime().ToLocalTime();
		EndDate = calenderEvent.RecurrenceLimitDate?.ToDateTime().ToLocalTime();
		TriggerDate = StartDate;
		RecurrenceDays = calenderEvent.RecurrenceDays.ToEventDay();
		RecurrenceExcludedDates.AddRange(calenderEvent.RecurrenceExcludedDates.Select((Pro.SerializationInterop.RVProtoData.Timestamp d) => d.ToDateTime().ToLocalTime()));
		if (calenderEvent.Actions.Empty())
		{
			ActionBase actionBase = null;
			switch (calenderEvent.Action.ActionTypeCase)
			{
			case Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action.ActionTypeOneofCase.Playlist:
				if (calenderEvent.Action.Playlist?.PlaylistUuid != null && ActionType.LibraryPlaylist.ConstructAction(null, "") is LibraryPlaylistAction libraryPlaylistAction)
				{
					libraryPlaylistAction.SetIdentifier(calenderEvent.Action.Playlist.PlaylistUuid.ToGuid(), string.Empty);
					actionBase = libraryPlaylistAction;
				}
				break;
			case Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.Action.ActionTypeOneofCase.Macro:
				if (ActionType.Macro.ConstructAction(null, "") is MacroAction macroAction)
				{
					CollectionElementType identification = calenderEvent.Action.Macro.Identification;
					macroAction.SetIdentifier(identification.ParameterUuid.ToGuid(), identification.ParameterName ?? string.Empty, identification.ParentCollection?.ParameterUuid.ToGuid() ?? Guid.Empty, identification.ParentCollection?.ParameterName ?? string.Empty);
					actionBase = macroAction;
				}
				break;
			}
			if (actionBase != null)
			{
				SetEventAction(actionBase);
			}
		}
		else
		{
			_actions.Deserialize(calenderEvent.Actions, new ApplicationData(ApplicationType.ProPresenter), "Workspace");
		}
	}

	public Event Clone()
	{
		Event @event = new Event();
		@event.CopyProperties(this);
		return @event;
	}

	public void SetEventAction(Pro.DO.Triggering.IAction? eventAction)
	{
		_actions.Clear();
		if (eventAction != null)
		{
			_actions.Add(eventAction);
		}
	}

	internal void CopyProperties(Event otherEvent)
	{
		_name = otherEvent._name;
		_description = otherEvent._description;
		_triggerDate = otherEvent._triggerDate;
		_startDate = otherEvent._startDate;
		_endDate = otherEvent._endDate;
		_recurrenceDays = otherEvent._recurrenceDays;
		_targetPlaylist = otherEvent._targetPlaylist;
		_targetCue = otherEvent._targetCue;
		_targetMacro = otherEvent._targetMacro;
		_actions.Clear();
		otherEvent.Actions.CloneItems().ForEach(_actions.Add);
		RecurrenceExcludedDates.Clear();
		RecurrenceExcludedDates.AddRange(otherEvent.RecurrenceExcludedDates.ToArray());
	}

	internal DayOfWeek[] GetRecurrenceDays()
	{
		return (from d in Enum.GetValues<EventDay>()
			where d != 0 && RecurrenceDays.HasFlag(d)
			select d into e
			select e.ToDayOfWeek()).ToArray();
	}
}
