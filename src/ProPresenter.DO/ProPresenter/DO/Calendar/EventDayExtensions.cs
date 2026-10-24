using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Calendar;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(EventDay), typeof(Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek), SourceToDestinationMethodName = "ToProtoDayOfWeek", DestinationDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEventDay", SourceDefaultValue = "Unknown")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(EventDay), typeof(ICalendar.Types.IEvent.Types.DayOfWeek), SourceToDestinationMethodName = "ToEntityDayOfWeek", DestinationDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEventDay", SourceDefaultValue = "Unknown")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek), typeof(ICalendar.Types.IEvent.Types.DayOfWeek), SourceToDestinationMethodName = "ToEntityDayOfWeek", DestinationDefaultValue = "Unknown", DestinationToSourceMethodName = "ToProtoDayOfWeek", SourceDefaultValue = "Unknown")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(DayOfWeek), typeof(EventDay), SourceToDestinationMethodName = "ToEventDay", DestinationDefaultValue = "Saturday", DestinationToSourceMethodName = "ToDayOfWeek", SourceDefaultValue = "Saturday", ExcludeDestinationNames = new string[] { "Unknown" })]
public static class EventDayExtensions
{
	public static EventDay ToEventDay(this IEnumerable<Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek> recurrenceDays)
	{
		EventDay dayOfWeek = EventDay.Unknown;
		recurrenceDays.ForEach(delegate(Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek d)
		{
			dayOfWeek |= d.ToEventDay();
		});
		return dayOfWeek;
	}

	public static EventDay ToEventDay(this IEnumerable<ICalendar.Types.IEvent.Types.DayOfWeek> recurrenceDays)
	{
		EventDay dayOfWeek = EventDay.Unknown;
		recurrenceDays.ForEach(delegate(ICalendar.Types.IEvent.Types.DayOfWeek d)
		{
			dayOfWeek |= d.ToEventDay();
		});
		return dayOfWeek;
	}

	public static IEnumerable<Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek> ToProtoRecurrenceDays(this EventDay recurrenceDays)
	{
		return from d in Enum.GetValues<EventDay>()
			where d != 0 && recurrenceDays.HasFlag(d)
			select d into e
			select e.ToProtoDayOfWeek();
	}

	public static IEnumerable<ICalendar.Types.IEvent.Types.DayOfWeek> ToEntityRecurrenceDays(this EventDay recurrenceDays)
	{
		return from d in Enum.GetValues<EventDay>()
			where d != 0 && recurrenceDays.HasFlag(d)
			select d into e
			select e.ToEntityDayOfWeek();
	}

	public static Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek ToProtoDayOfWeek(this EventDay source)
	{
		return source switch
		{
			EventDay.Unknown => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown, 
			EventDay.Sunday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Sunday, 
			EventDay.Monday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Monday, 
			EventDay.Tuesday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Tuesday, 
			EventDay.Wednesday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Wednesday, 
			EventDay.Thursday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Thursday, 
			EventDay.Friday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Friday, 
			EventDay.Saturday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Saturday, 
			_ => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown, 
		};
	}

	public static EventDay ToEventDay(this Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown => EventDay.Unknown, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Sunday => EventDay.Sunday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Monday => EventDay.Monday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Tuesday => EventDay.Tuesday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Wednesday => EventDay.Wednesday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Thursday => EventDay.Thursday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Friday => EventDay.Friday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Saturday => EventDay.Saturday, 
			_ => EventDay.Unknown, 
		};
	}

	public static ICalendar.Types.IEvent.Types.DayOfWeek ToEntityDayOfWeek(this EventDay source)
	{
		return source switch
		{
			EventDay.Unknown => ICalendar.Types.IEvent.Types.DayOfWeek.Unknown, 
			EventDay.Sunday => ICalendar.Types.IEvent.Types.DayOfWeek.Sunday, 
			EventDay.Monday => ICalendar.Types.IEvent.Types.DayOfWeek.Monday, 
			EventDay.Tuesday => ICalendar.Types.IEvent.Types.DayOfWeek.Tuesday, 
			EventDay.Wednesday => ICalendar.Types.IEvent.Types.DayOfWeek.Wednesday, 
			EventDay.Thursday => ICalendar.Types.IEvent.Types.DayOfWeek.Thursday, 
			EventDay.Friday => ICalendar.Types.IEvent.Types.DayOfWeek.Friday, 
			EventDay.Saturday => ICalendar.Types.IEvent.Types.DayOfWeek.Saturday, 
			_ => ICalendar.Types.IEvent.Types.DayOfWeek.Unknown, 
		};
	}

	public static EventDay ToEventDay(this ICalendar.Types.IEvent.Types.DayOfWeek source)
	{
		return source switch
		{
			ICalendar.Types.IEvent.Types.DayOfWeek.Unknown => EventDay.Unknown, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Sunday => EventDay.Sunday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Monday => EventDay.Monday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Tuesday => EventDay.Tuesday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Wednesday => EventDay.Wednesday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Thursday => EventDay.Thursday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Friday => EventDay.Friday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Saturday => EventDay.Saturday, 
			_ => EventDay.Unknown, 
		};
	}

	public static ICalendar.Types.IEvent.Types.DayOfWeek ToEntityDayOfWeek(this Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown => ICalendar.Types.IEvent.Types.DayOfWeek.Unknown, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Sunday => ICalendar.Types.IEvent.Types.DayOfWeek.Sunday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Monday => ICalendar.Types.IEvent.Types.DayOfWeek.Monday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Tuesday => ICalendar.Types.IEvent.Types.DayOfWeek.Tuesday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Wednesday => ICalendar.Types.IEvent.Types.DayOfWeek.Wednesday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Thursday => ICalendar.Types.IEvent.Types.DayOfWeek.Thursday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Friday => ICalendar.Types.IEvent.Types.DayOfWeek.Friday, 
			Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Saturday => ICalendar.Types.IEvent.Types.DayOfWeek.Saturday, 
			_ => ICalendar.Types.IEvent.Types.DayOfWeek.Unknown, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek ToProtoDayOfWeek(this ICalendar.Types.IEvent.Types.DayOfWeek source)
	{
		return source switch
		{
			ICalendar.Types.IEvent.Types.DayOfWeek.Unknown => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Sunday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Sunday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Monday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Monday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Tuesday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Tuesday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Wednesday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Wednesday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Thursday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Thursday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Friday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Friday, 
			ICalendar.Types.IEvent.Types.DayOfWeek.Saturday => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Saturday, 
			_ => Pro.SerializationInterop.RVProtoData.Calendar.Types.Event.Types.DayOfWeek.Unknown, 
		};
	}

	public static EventDay ToEventDay(this DayOfWeek source)
	{
		return source switch
		{
			DayOfWeek.Sunday => EventDay.Sunday, 
			DayOfWeek.Monday => EventDay.Monday, 
			DayOfWeek.Tuesday => EventDay.Tuesday, 
			DayOfWeek.Wednesday => EventDay.Wednesday, 
			DayOfWeek.Thursday => EventDay.Thursday, 
			DayOfWeek.Friday => EventDay.Friday, 
			DayOfWeek.Saturday => EventDay.Saturday, 
			_ => EventDay.Saturday, 
		};
	}

	public static DayOfWeek ToDayOfWeek(this EventDay source)
	{
		return source switch
		{
			EventDay.Sunday => DayOfWeek.Sunday, 
			EventDay.Monday => DayOfWeek.Monday, 
			EventDay.Tuesday => DayOfWeek.Tuesday, 
			EventDay.Wednesday => DayOfWeek.Wednesday, 
			EventDay.Thursday => DayOfWeek.Thursday, 
			EventDay.Friday => DayOfWeek.Friday, 
			EventDay.Saturday => DayOfWeek.Saturday, 
			_ => DayOfWeek.Saturday, 
		};
	}
}
