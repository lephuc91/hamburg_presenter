using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerFormatStyle), typeof(Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style), SourceToDestinationMethodName = "GetProtoFormatStyle", DestinationDefaultValue = "None", DestinationToSourceMethodName = "GetFormatStyle", SourceDefaultValue = "None", UnmatchedDestinationNames = new string[] { "RemoveLong", "RemoveShort" }, UnmatchedSourceNames = new string[] { "LongTruncated", "ShortTruncated" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerFormatStyle), typeof(ITimer.Types.IFormat.Types.Style), SourceToDestinationMethodName = "GetEntityFormatStyle", DestinationDefaultValue = "None", DestinationToSourceMethodName = "GetFormatStyle", SourceDefaultValue = "None", UnmatchedDestinationNames = new string[] { "RemoveLong", "RemoveShort" }, UnmatchedSourceNames = new string[] { "LongTruncated", "ShortTruncated" })]
public static class TimerFormatStyleExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style GetProtoFormatStyle(this TimerFormatStyle source)
	{
		return source switch
		{
			TimerFormatStyle.None => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.None, 
			TimerFormatStyle.Short => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Short, 
			TimerFormatStyle.Long => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long, 
			TimerFormatStyle.ShortTruncated => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.RemoveShort, 
			TimerFormatStyle.LongTruncated => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.RemoveLong, 
			_ => Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.None, 
		};
	}

	public static TimerFormatStyle GetFormatStyle(this Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.None => TimerFormatStyle.None, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Short => TimerFormatStyle.Short, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long => TimerFormatStyle.Long, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.RemoveShort => TimerFormatStyle.ShortTruncated, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.RemoveLong => TimerFormatStyle.LongTruncated, 
			_ => TimerFormatStyle.None, 
		};
	}

	public static ITimer.Types.IFormat.Types.Style GetEntityFormatStyle(this TimerFormatStyle source)
	{
		return source switch
		{
			TimerFormatStyle.None => ITimer.Types.IFormat.Types.Style.None, 
			TimerFormatStyle.Short => ITimer.Types.IFormat.Types.Style.Short, 
			TimerFormatStyle.Long => ITimer.Types.IFormat.Types.Style.Long, 
			TimerFormatStyle.ShortTruncated => ITimer.Types.IFormat.Types.Style.RemoveShort, 
			TimerFormatStyle.LongTruncated => ITimer.Types.IFormat.Types.Style.RemoveLong, 
			_ => ITimer.Types.IFormat.Types.Style.None, 
		};
	}

	public static TimerFormatStyle GetFormatStyle(this ITimer.Types.IFormat.Types.Style source)
	{
		return source switch
		{
			ITimer.Types.IFormat.Types.Style.None => TimerFormatStyle.None, 
			ITimer.Types.IFormat.Types.Style.Short => TimerFormatStyle.Short, 
			ITimer.Types.IFormat.Types.Style.Long => TimerFormatStyle.Long, 
			ITimer.Types.IFormat.Types.Style.RemoveShort => TimerFormatStyle.ShortTruncated, 
			ITimer.Types.IFormat.Types.Style.RemoveLong => TimerFormatStyle.LongTruncated, 
			_ => TimerFormatStyle.None, 
		};
	}
}
