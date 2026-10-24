using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

public static class TimerFactory
{
	public static TimerData? ToTimerData(this string timerType)
	{
		if (!Enum.TryParse<TimerType>(timerType, out var result))
		{
			if (timerType.Equals("CountDownTimer"))
			{
				result = TimerType.Countdown;
			}
			else if (timerType.Equals("CountDownToTimer"))
			{
				result = TimerType.CountdownToTime;
			}
			else
			{
				if (!timerType.Equals("ElapsedTimer"))
				{
					return null;
				}
				result = TimerType.ElapsedTime;
			}
		}
		return CreateTimer(result);
	}

	public static TimerData? CreateTimer(TimerType timerType)
	{
		return timerType switch
		{
			TimerType.Countdown => new TimerData(new CountdownTimer(), null), 
			TimerType.CountdownToTime => new TimerData(new CountdownToTime(), null), 
			TimerType.ElapsedTime => new TimerData(new ElapsedTime(), null), 
			_ => null, 
		};
	}

	public static TimerBase? CreateTimerSource(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.TimerTypeOneofCase? protoTimerType)
	{
		if (protoTimerType.HasValue)
		{
			return CreateTimerSource(protoTimerType.Value.ToTimerType());
		}
		return null;
	}

	public static TimerBase? CreateTimerSource(TimerType timerType)
	{
		return timerType switch
		{
			TimerType.Countdown => new CountdownTimer(), 
			TimerType.CountdownToTime => new CountdownToTime(), 
			TimerType.ElapsedTime => new ElapsedTime(), 
			_ => null, 
		};
	}
}
