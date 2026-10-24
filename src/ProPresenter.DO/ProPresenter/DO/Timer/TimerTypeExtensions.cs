using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerType), typeof(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase), SourceToDestinationMethodName = "ToProtoTimerType", DestinationToSourceMethodName = "ToTimerType", SourceDefaultValue = "Countdown", DestinationDefaultValue = "Countdown", ExcludeDestinationNames = new string[] { "None" })]
public static class TimerTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase ToProtoTimerType(this TimerType source)
	{
		return source switch
		{
			TimerType.Countdown => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.Countdown, 
			TimerType.CountdownToTime => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.CountdownToTime, 
			TimerType.ElapsedTime => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.ElapsedTime, 
			_ => Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.Countdown, 
		};
	}

	public static TimerType ToTimerType(this Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.Countdown => TimerType.Countdown, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.CountdownToTime => TimerType.CountdownToTime, 
			Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase.ElapsedTime => TimerType.ElapsedTime, 
			_ => TimerType.Countdown, 
		};
	}
}
