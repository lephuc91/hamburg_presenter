using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Timer;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle), typeof(FormatLength), SourceToDestinationMethodName = "ToFormatLength", DestinationToSourceMethodName = "ToProtoFormatterStyle")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IClock.Types.IFormat.Types.DateFormatterStyle), typeof(FormatLength), SourceToDestinationMethodName = "ToFormatLength", DestinationToSourceMethodName = "ToEntityFormatterStyle")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod), typeof(TimeFormat), SourceToDestinationMethodName = "ToTimeFormat", DestinationToSourceMethodName = "ToProtoTimerPeriod", DestinationDefaultValue = "AM", SourceDefaultValue = "Am", UnmatchedDestinationNames = new string[] { "AM", "PM", "TwentyFour" }, UnmatchedSourceNames = new string[] { "Am", "Pm", "_24" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod), typeof(TimeFormat), SourceToDestinationMethodName = "ToTimeFormat", DestinationToSourceMethodName = "ToEntityTimerPeriod", SourceDefaultValue = "Am", DestinationDefaultValue = "AM", UnmatchedDestinationNames = new string[] { "AM", "PM", "TwentyFour" }, UnmatchedSourceNames = new string[] { "Am", "Pm", "_24" })]
public static class TimerHelper
{
	public static string FormatTime(this TimeSlice time, double frameRate, bool showSubSeconds = true, TimerFormatData? formatData = null)
	{
		double num = ((frameRate != 0.0) ? (time.TotalSeconds * frameRate % frameRate) : frameRate);
		string text = formatData?.FormatTime(time) ?? TimeSliceHelper.TimeSliceToString(time);
		if (!showSubSeconds)
		{
			return text;
		}
		return text + ";" + num.ToString("00");
	}

	public static TimerActionType GetTimerActionType(this TimerData timer, TimerActionType timerActionType)
	{
		if (timerActionType == TimerActionType.Start)
		{
			TimerBase active = timer.Active;
			timerActionType = ((active != null && active.State == TimerState.Reset) ? TimerActionType.ResetAndStart : TimerActionType.Start);
		}
		return timerActionType;
	}

	public static FormatLength ToFormatLength(this Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.None => FormatLength.None, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Short => FormatLength.Short, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Medium => FormatLength.Medium, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Long => FormatLength.Long, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Full => FormatLength.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle ToProtoFormatterStyle(this FormatLength source)
	{
		return source switch
		{
			FormatLength.None => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.None, 
			FormatLength.Short => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Short, 
			FormatLength.Medium => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Medium, 
			FormatLength.Long => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Long, 
			FormatLength.Full => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static FormatLength ToFormatLength(this IClock.Types.IFormat.Types.DateFormatterStyle source)
	{
		return source switch
		{
			IClock.Types.IFormat.Types.DateFormatterStyle.None => FormatLength.None, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Short => FormatLength.Short, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Medium => FormatLength.Medium, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Long => FormatLength.Long, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Full => FormatLength.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IClock.Types.IFormat.Types.DateFormatterStyle ToEntityFormatterStyle(this FormatLength source)
	{
		return source switch
		{
			FormatLength.None => IClock.Types.IFormat.Types.DateFormatterStyle.None, 
			FormatLength.Short => IClock.Types.IFormat.Types.DateFormatterStyle.Short, 
			FormatLength.Medium => IClock.Types.IFormat.Types.DateFormatterStyle.Medium, 
			FormatLength.Long => IClock.Types.IFormat.Types.DateFormatterStyle.Long, 
			FormatLength.Full => IClock.Types.IFormat.Types.DateFormatterStyle.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static TimeFormat ToTimeFormat(this Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Am => TimeFormat.AM, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Pm => TimeFormat.PM, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod._24 => TimeFormat.TwentyFour, 
			_ => TimeFormat.AM, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod ToProtoTimerPeriod(this TimeFormat source)
	{
		return source switch
		{
			TimeFormat.AM => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Am, 
			TimeFormat.PM => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Pm, 
			TimeFormat.TwentyFour => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod._24, 
			_ => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Am, 
		};
	}

	public static TimeFormat ToTimeFormat(this ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod source)
	{
		return source switch
		{
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Am => TimeFormat.AM, 
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Pm => TimeFormat.PM, 
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod._24 => TimeFormat.TwentyFour, 
			_ => TimeFormat.AM, 
		};
	}

	public static ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod ToEntityTimerPeriod(this TimeFormat source)
	{
		return source switch
		{
			TimeFormat.AM => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Am, 
			TimeFormat.PM => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Pm, 
			TimeFormat.TwentyFour => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod._24, 
			_ => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Am, 
		};
	}
}
