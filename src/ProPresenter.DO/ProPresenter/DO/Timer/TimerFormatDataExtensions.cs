using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Timer;

public static class TimerFormatDataExtensions
{
	private static IEnumerable<TimerFormatStyle> AllStyles = Enum.GetValues<TimerFormatStyle>();

	public static IEnumerable<TimerFormatStyle> GetAvailableHourFormats(this TimerFormatData data)
	{
		return AllStyles;
	}

	public static IEnumerable<TimerFormatStyle> GetAvailableMinuteFormats(this TimerFormatData data)
	{
		if (data.HourFormat == TimerFormatStyle.Long || data.HourFormat == TimerFormatStyle.Short)
		{
			return new global::_003C_003Ez__ReadOnlyArray<TimerFormatStyle>(new TimerFormatStyle[2]
			{
				TimerFormatStyle.Long,
				TimerFormatStyle.None
			});
		}
		return AllStyles;
	}

	public static IEnumerable<TimerFormatStyle> GetAvailableSecondFormats(this TimerFormatData data)
	{
		if (data.MinuteFormat == TimerFormatStyle.Long || data.MinuteFormat == TimerFormatStyle.Short)
		{
			return new global::_003C_003Ez__ReadOnlyArray<TimerFormatStyle>(new TimerFormatStyle[2]
			{
				TimerFormatStyle.Long,
				TimerFormatStyle.None
			});
		}
		return AllStyles;
	}

	public static IEnumerable<TimerFormatStyle> GetAvailableMillisecondFormats(this TimerFormatData data)
	{
		if (data.SecondFormat == TimerFormatStyle.Long || data.MinuteFormat == TimerFormatStyle.Short)
		{
			return new global::_003C_003Ez__ReadOnlyArray<TimerFormatStyle>(new TimerFormatStyle[3]
			{
				TimerFormatStyle.Long,
				TimerFormatStyle.Short,
				TimerFormatStyle.None
			});
		}
		return AllStyles;
	}
}
