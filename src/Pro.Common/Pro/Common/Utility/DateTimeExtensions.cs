using System;

namespace Pro.Common.Utility;

public static class DateTimeExtensions
{
	private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

	public static long ToUnixTimestamp(this DateTime timestamp)
	{
		return (long)(timestamp.ToUniversalTime() - Epoch).TotalSeconds;
	}

	public static DateTime FromUnixTimestamp(this long timestamp)
	{
		return Epoch.AddSeconds(timestamp);
	}

	public static DateTime FromUnixTimestamp(this ulong timestamp)
	{
		return Epoch.AddSeconds(timestamp);
	}

	public static string ToRelativeTime(this DateTime timestamp)
	{
		TimeSpan timeSpan = DateTime.Now - timestamp;
		if (timeSpan < TimeSpan.FromSeconds(60.0))
		{
			return timeSpan.Seconds + "s";
		}
		if (timeSpan < TimeSpan.FromMinutes(60.0))
		{
			return timeSpan.Minutes + "m";
		}
		if (timeSpan < TimeSpan.FromHours(24.0))
		{
			return timeSpan.Hours + "h";
		}
		return timeSpan.Days + "d";
	}

	public static DateTime TruncateHours(this DateTime timestamp)
	{
		return timestamp.AddHours(-timestamp.Hour);
	}

	public static DateTime TruncateMinutes(this DateTime timestamp)
	{
		return timestamp.AddMinutes(-timestamp.Minute);
	}

	public static DateTime TruncateSeconds(this DateTime timestamp)
	{
		return timestamp.AddSeconds(-timestamp.Second);
	}

	public static DateTime TruncateMilliseconds(this DateTime timestamp)
	{
		return timestamp.AddMilliseconds(-timestamp.Millisecond);
	}

	public static DateTime TruncateToSeconds(this DateTime timestamp)
	{
		return new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, timestamp.Hour, timestamp.Minute, timestamp.Second, timestamp.Kind);
	}
}
