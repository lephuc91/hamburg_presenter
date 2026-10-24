using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Calendar;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer", "_syncedData" })]
public class EventCalendar : ImmutableObservableCollection<EventCollection>, IEventCalendar, INotifyEnumerableChanged<EventCollection>, IEnumerable<EventCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IDocumentProvider, IDisposable
{
	private static readonly TimeSlice EventCheckInterval = TimeSlice.FromSeconds(0.5);

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IFlagService _flagService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly IPeriodicTimer _timer;

	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.Calendar>? _syncedData;

	private IEntityDocumentSyncer<ICalendarDoc>? _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool IsActive
	{
		get
		{
			return _timer.IsRunning();
		}
		set
		{
			if (value)
			{
				if (!_timer.IsRunning())
				{
					_timer.Start();
					OnDataModified();
					OnPropertyChanged("IsActive");
				}
			}
			else if (_timer.IsRunning())
			{
				_timer.Stop();
				OnDataModified();
				OnPropertyChanged("IsActive");
			}
		}
	}

	public Event? ActiveEvent { get; private set; }

	public IEnumerable<Event> PastEvents { get; private set; }

	public IEnumerable<Event> CurrentEvents { get; private set; }

	public IEnumerable<Event> UpcomingEvents { get; private set; }

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event Action<Event>? EventTriggered;

	public static ObjectBinder<EventCalendar, ICalendar> CreateBinder(IEntityFactory entityFactory, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, EventCalendar left, ICalendar right)
	{
		return new ObjectBinder<EventCalendar, ICalendar>(left, right).Bind((EventCalendar l) => l.Collection.WhenCollectionChanges(), (ICalendar r) => r.Events.WhenCollectionChanges, delegate(EventCalendar l, ICalendar r)
		{
			r.Events.SynchronizeFrom(l.Collection, (EventCollection model, ICalendar.Types.IEvent entity) => entity.Uuid.Value == model.Main.ID, delegate(EventCollection model)
			{
				ICalendar.Types.IEvent @event = entityFactory.Create<ICalendar.Types.IEvent>();
				ObjectBinder<Event, ICalendar.Types.IEvent> objectBinder = Event.CreateBinder(scheduler, entityFactory, actionBinderFactory, model.Main, @event);
				objectBinder.InitializeRightFromLeft();
				@event.RegisterLinkedDisposable(objectBinder);
				return @event;
			});
		}, delegate(ICalendar r, EventCalendar l)
		{
			r.Events.Items.SynchronizeTo(l.Collection, (ICalendar.Types.IEvent e, EventCollection m) => m.Main.ID == e.Uuid.Value, delegate(ICalendar.Types.IEvent e, int i)
			{
				Event event2 = new Event();
				ObjectBinder<Event, ICalendar.Types.IEvent> objectBinder2 = Event.CreateBinder(scheduler, entityFactory, actionBinderFactory, event2, e);
				objectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder2);
				l.InsertEvent(new EventCollection(event2), i);
			}, l.Collection.Move, delegate(int index)
			{
				EventCollection group = l.Collection[index];
				l.RemoveEvent(group);
			});
		}, null, scheduler.Scheduler);
	}

	public EventCalendar(ISyncDataFactory syncDataFactory, ITimerFactory timerFactory, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, bool loadLegacy)
	{
		_timer = timerFactory.CreatePeriodicDispatched(EventCheckInterval, TimerTick);
		_timer.Start();
		_syncDataFactory = syncDataFactory;
		_flagService = flagService;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		SetupDocumentSyncer(loadLegacy);
		OnEventsUpdated();
		base.CollectionChanged += delegate
		{
			OnEventsUpdated();
			OnDataModified();
		};
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void LoadDefaults()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncer = null;
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Calendar", (ICalendarDoc doc) => CreateBinder(_factoryProvider.EntityFactory, _scheduler, _actionBinderFactory, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(Pro.SerializationInterop.RVProtoData.Calendar.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.Calendar>(CommonPaths.Configuration, "Calendar", SyncDataUpdated, SyncDataCleared);
		}
	}

	private void TimerTick()
	{
		if (UpcomingEvents.Any())
		{
			Event @event = UpcomingEvents.FirstOrDefault((Event g) => g.TriggerDate <= DateTime.Now);
			if (@event != null && ActiveEvent != @event)
			{
				ActiveEvent = FindGroup(@event)?.Main;
				ExecuteEvent(@event);
				OnEventsUpdated();
			}
		}
	}

	[MemberNotNull(new string[] { "PastEvents", "UpcomingEvents", "CurrentEvents" })]
	private void OnEventsUpdated()
	{
		DateTime dt = DateTime.Now;
		Event[] source = base.Collection.SelectMany((EventCollection g) => g.Events).ToArray();
		CurrentEvents = ((ActiveEvent == null || ActiveEvent.RecurrenceDays != 0) ? Array.Empty<Event>() : (FindGroup(ActiveEvent)?.ToArray() ?? Array.Empty<Event>()));
		PastEvents = (from e in source.Where((Event e) => e.TriggerDate < dt && e.RecurrenceDays == EventDay.Unknown).Except(CurrentEvents)
			orderby e.TriggerDate
			select e).ToArray();
		UpcomingEvents = (from e in source
			where e.TriggerDate > dt
			orderby e.TriggerDate
			select e).ToArray();
		OnPropertyChanged("PastEvents");
		OnPropertyChanged("CurrentEvents");
		OnPropertyChanged("UpcomingEvents");
	}

	public void AddEvent()
	{
		AddEvent(new Event());
	}

	public void AddEvent(Event calendarEvent)
	{
		AddEvent(new EventCollection(calendarEvent));
	}

	public void AddEvent(EventCollection eventCollection)
	{
		eventCollection.EventRangeUpdated += EventCollection_EventRangeUpdated;
		eventCollection.DataModified += OnDataModified;
		base.Collection.Add(eventCollection);
	}

	private void InsertEvent(EventCollection eventCollection, int index)
	{
		eventCollection.EventRangeUpdated += EventCollection_EventRangeUpdated;
		eventCollection.DataModified += OnDataModified;
		base.Collection.Insert(index, eventCollection);
	}

	public void RemoveEvent(Event calendarEvent)
	{
		RemoveEvent(FindGroup(calendarEvent));
	}

	public void RemoveEvent(EventCollection? group)
	{
		if (group != null)
		{
			group.EventRangeUpdated -= EventCollection_EventRangeUpdated;
			group.DataModified -= OnDataModified;
			group.Main.SetEventAction(null);
			base.Collection.Remove(group);
		}
	}

	private void EventCollection_EventRangeUpdated()
	{
		OnEventsUpdated();
	}

	private void SyncDataUpdated(Pro.SerializationInterop.RVProtoData.Calendar protoCalendar)
	{
		Deserialize(protoCalendar);
	}

	private void SyncDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			base.Collection.ToArray().ForEach(RemoveEvent);
		}
	}

	private void OnDataModified()
	{
		_syncedData?.UpdateData(Serialize());
	}

	internal void Save()
	{
		OnDataModified();
	}

	public EventCollection? FindGroup(Event calendarEvent)
	{
		return base.Collection.FirstOrDefault((EventCollection g) => g.Main == calendarEvent || g.Contains(calendarEvent));
	}

	private Pro.SerializationInterop.RVProtoData.Calendar Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Calendar calendar = new Pro.SerializationInterop.RVProtoData.Calendar();
		calendar.Active = IsActive;
		calendar.Events.AddRange(base.Collection.Select((EventCollection e) => e.Main.Serialize()));
		return calendar;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Calendar protoCalendar, bool removeExisting = true)
	{
		if (protoCalendar == null)
		{
			return;
		}
		IsActive = protoCalendar.Active;
		List<Tuple<Event, IEnumerable<DateTime>>> eventAndExcludeDates2 = new List<Tuple<Event, IEnumerable<DateTime>>>();
		base.Collection.Select((EventCollection g) => g.Main).DeserializeCollection(protoCalendar.Events, (Event e, Pro.SerializationInterop.RVProtoData.Calendar.Types.Event d) => e.ID == d.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.Calendar.Types.Event d) => new Event(), AddEvent, delegate(Event e)
		{
			if (removeExisting)
			{
				RemoveEvent(e);
			}
		}, delegate(Event e, Pro.SerializationInterop.RVProtoData.Calendar.Types.Event d)
		{
			e.Deserialize(d);
			eventAndExcludeDates2.Add(new Tuple<Event, IEnumerable<DateTime>>(e, e.RecurrenceExcludedDates.ToArray()));
		});
		removeAllExcludedEvents(eventAndExcludeDates2);
		void removeAllExcludedEvents(List<Tuple<Event, IEnumerable<DateTime>>> eventAndExcludeDates)
		{
			foreach (Tuple<Event, IEnumerable<DateTime>> eventAndExcludeDate in eventAndExcludeDates)
			{
				EventCollection eventCollection = FindGroup(eventAndExcludeDate.Item1);
				if (eventCollection != null)
				{
					eventCollection.DataModified -= OnDataModified;
					foreach (DateTime date in eventAndExcludeDate.Item2)
					{
						Event @event = eventCollection.FirstOrDefault((Event g) => g.TriggerDate == date);
						if (@event != null)
						{
							eventCollection.RemoveRecurringEvent(@event);
						}
					}
					eventCollection.DataModified += OnDataModified;
				}
			}
		}
	}

	public void ExecuteEvent(Event calendarEvent)
	{
		if (calendarEvent != null)
		{
			this.EventTriggered?.Invoke(calendarEvent);
		}
	}

	public void RemoveRecurringEvent(Event recurringEvent, bool removeAllOccurrences)
	{
		EventCollection eventCollection = FindGroup(recurringEvent);
		eventCollection.ThrowWhenNull("group");
		if (removeAllOccurrences)
		{
			RemoveEvent(eventCollection);
			return;
		}
		eventCollection.Main.RecurrenceExcludedDates.Add(recurringEvent.TriggerDate);
		eventCollection.RemoveRecurringEvent(recurringEvent);
	}

	public Event UpdateRecurringEvent(Event recurringEvent, string eventName, string eventDescription, DateTime newDate, Pro.DO.Triggering.IAction? eventAction, bool updateFutureEvents)
	{
		EventCollection eventCollection = FindGroup(recurringEvent);
		eventCollection.ThrowWhenNull("targetGroup");
		Event main = eventCollection.Main;
		Event @event = main.Clone();
		@event.Name = eventName;
		@event.Description = eventDescription;
		@event.SetEventAction(eventAction);
		@event.StartDate = newDate;
		if (updateFutureEvents)
		{
			DateTime? endDate = main.EndDate;
			Event? previous = eventCollection.GetPrevious(recurringEvent);
			main.EndDate = ((previous != null) ? new DateTime?(previous.TriggerDate) : recurringEvent.EndDate);
			@event.EndDate = endDate;
		}
		else
		{
			main.RecurrenceExcludedDates.Add(recurringEvent.TriggerDate);
			@event.RecurrenceDays = EventDay.Unknown;
		}
		AddEvent(@event);
		return @event;
	}

	public Event UpdateRecurringEventRepeatType(Event recurringEvent, EventDay day, DateTime? newEndDate, bool canEnd)
	{
		EventCollection eventCollection = FindGroup(recurringEvent);
		eventCollection.ThrowWhenNull("targetGroup");
		Event main = eventCollection.Main;
		Event @event = main.Clone();
		@event.StartDate = recurringEvent.TriggerDate;
		@event.RecurrenceDays = day;
		@event.EndDate = (canEnd ? new DateTime?(newEndDate ?? recurringEvent.TriggerDate) : ((DateTime?)null));
		AddEvent(@event);
		Event? previous = eventCollection.GetPrevious(recurringEvent);
		main.EndDate = ((previous != null) ? new DateTime?(previous.TriggerDate) : recurringEvent.EndDate);
		return @event;
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new CalendarDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_syncer?.Dispose();
			_syncedData?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
