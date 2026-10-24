using System;
using Pro.Common.Utility;
using Pro.Entity.Properties;

namespace Pro.Entity;

public static class TimestampExtensions
{
	public static DateTime ToLocalDateTime(this Timestamp stamp)
	{
		return stamp.Seconds.FromUnixTimestamp().ToLocalTime();
	}

	public static DateTime ToLocalDateTime(this IObservableProperty<Timestamp> property)
	{
		return property.Value.ToLocalDateTime();
	}

	public static Timestamp ToTimestamp(this DateTime value)
	{
		return new Timestamp(value.ToUnixTimestamp(), 0);
	}
}
