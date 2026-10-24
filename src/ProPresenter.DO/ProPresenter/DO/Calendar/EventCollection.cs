using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Calendar;

public class EventCollection : ImmutableObservableCollection<Event>
{
	public Event Main { get; }

	public IEnumerable<Event> Events => base.Collection.Where((Event e) => !Main.RecurrenceExcludedDates.Contains(e.TriggerDate));

	public event Action? DataModified;

	public event Action? EventRangeUpdated;

	public EventCollection(Event calendarEvent)
	{
		Main = calendarEvent ?? throw new ArgumentNullException();
		Main.RecurrencesUpdated += UpdateRecurrences;
		Main.DataModified += OnDataModified;
		Main.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name")
			{
				base.Collection.ForEach(delegate(Event c)
				{
					c.Name = Main.Name;
				});
			}
		};
		UpdateRecurrences();
	}

	private void UpdateRecurrences()
	{
		DateTime? dateTime = Main.EndDate;
		if (!dateTime.HasValue)
		{
			DateTime now = DateTime.Now;
			dateTime = Main.StartDate.AddMonths(6);
			if (dateTime < now)
			{
				dateTime = now.AddMonths(6);
			}
		}
		PopulateEventRange(Main.StartDate, dateTime.Value);
	}

	public void RemoveRecurringEvent(Event calendarEvent)
	{
		base.Collection.Remove(calendarEvent);
		if (!base.Collection.Any() && !Main.EndDate.HasValue)
		{
			PopulateEventRange(calendarEvent.TriggerDate, calendarEvent.TriggerDate.AddMonths(6));
		}
		else
		{
			this.EventRangeUpdated?.Invoke();
		}
	}

	private void PopulateEventRange(DateTime start, DateTime end)
	{
		DayOfWeek[] array = Main.GetRecurrenceDays();
		DateTime dateTime = start;
		List<DateTime> list = new List<DateTime>();
		Main.RecurrenceExcludedDates.Clear();
		if (!array.Any())
		{
			array = new DayOfWeek[1] { dateTime.DayOfWeek };
			end = dateTime;
		}
		int num = array.IndexOf(dateTime.DayOfWeek);
		while (dateTime <= end)
		{
			list.Add(dateTime);
			int num2 = array[++num % array.Length] - dateTime.DayOfWeek;
			dateTime = dateTime.AddDays(((num2 <= 0) ? 7 : 0) + num2);
		}
		int num3 = base.Collection.Count - list.Count;
		base.Collection.RemoveAtRange(Math.Max(0, list.Count - 1), num3);
		if (num3 < 0)
		{
			for (int i = 0; i < Math.Abs(num3); i++)
			{
				base.Collection.Add(Main.Clone());
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			base.Collection[j].CopyProperties(Main);
			base.Collection[j].TriggerDate = list[j];
		}
		this.EventRangeUpdated?.Invoke();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
