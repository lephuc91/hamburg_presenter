using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Calendar;

public interface IEventCalendar : INotifyEnumerableChanged<EventCollection>, IEnumerable<EventCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IDocumentProvider
{
	Event? ActiveEvent { get; }

	IEnumerable<Event> CurrentEvents { get; }

	bool IsActive { get; set; }

	IEnumerable<Event> PastEvents { get; }

	IEnumerable<Event> UpcomingEvents { get; }

	event Action<Event> EventTriggered;

	void AddEvent();

	void AddEvent(Event calendarEvent);

	void AddEvent(EventCollection eventCollection);

	void Deserialize(Pro.SerializationInterop.RVProtoData.Calendar protoCalendar, bool removeExisting = true);

	void ExecuteEvent(Event calendarEvent);

	EventCollection? FindGroup(Event calendarEvent);

	void RemoveEvent(Event calendarEvent);

	void RemoveEvent(EventCollection? group);

	void RemoveRecurringEvent(Event recurringEvent, bool removeAllOccurrences);

	Event UpdateRecurringEvent(Event recurringEvent, string eventName, string eventDescription, DateTime newDate, IAction? eventAction, bool updateFutureEvents);

	Event UpdateRecurringEventRepeatType(Event recurringEvent, EventDay day, DateTime? newEndDate, bool canEnd);
}
