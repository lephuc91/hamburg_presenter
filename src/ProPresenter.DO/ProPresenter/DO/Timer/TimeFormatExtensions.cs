using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimeFormat), typeof(API_v1_Timer.Types.API_v1_TimePeriod), SourceToDestinationMethodName = "Serialize", DestinationToSourceMethodName = "Deserialize", UnmatchedSourceNames = new string[] { "AM", "PM", "TwentyFour" }, UnmatchedDestinationNames = new string[] { "Am", "Pm", "Is24Hour" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimeFormat), typeof(ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod), SourceToDestinationMethodName = "EntitySerialize", DestinationDefaultValue = "_24", DestinationToSourceMethodName = "Deserialize", SourceDefaultValue = "TwentyFour", UnmatchedSourceNames = new string[] { "AM", "PM", "TwentyFour" }, UnmatchedDestinationNames = new string[] { "Am", "Pm", "_24" })]
public static class TimeFormatExtensions
{
	public static API_v1_Timer.Types.API_v1_TimePeriod Serialize(this TimeFormat source)
	{
		return source switch
		{
			TimeFormat.AM => API_v1_Timer.Types.API_v1_TimePeriod.Am, 
			TimeFormat.PM => API_v1_Timer.Types.API_v1_TimePeriod.Pm, 
			TimeFormat.TwentyFour => API_v1_Timer.Types.API_v1_TimePeriod.Is24Hour, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static TimeFormat Deserialize(this API_v1_Timer.Types.API_v1_TimePeriod source)
	{
		return source switch
		{
			API_v1_Timer.Types.API_v1_TimePeriod.Am => TimeFormat.AM, 
			API_v1_Timer.Types.API_v1_TimePeriod.Pm => TimeFormat.PM, 
			API_v1_Timer.Types.API_v1_TimePeriod.Is24Hour => TimeFormat.TwentyFour, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod EntitySerialize(this TimeFormat source)
	{
		return source switch
		{
			TimeFormat.AM => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Am, 
			TimeFormat.PM => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Pm, 
			TimeFormat.TwentyFour => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod._24, 
			_ => ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod._24, 
		};
	}

	public static TimeFormat Deserialize(this ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod source)
	{
		return source switch
		{
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Am => TimeFormat.AM, 
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod.Pm => TimeFormat.PM, 
			ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime.Types.TimePeriod._24 => TimeFormat.TwentyFour, 
			_ => TimeFormat.TwentyFour, 
		};
	}
}
