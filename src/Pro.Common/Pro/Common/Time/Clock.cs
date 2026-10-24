using System.Diagnostics;

namespace Pro.Common.Time;

public class Clock
{
	internal static readonly double Frequency = Stopwatch.Frequency;

	private readonly Stopwatch _stopwatch = new Stopwatch();

	private TimeSlice _elapsed = TimeSlice.Zero;

	public TimeSlice ElapsedTime
	{
		get
		{
			return new TimeSlice(_stopwatch.ElapsedTicks) + _elapsed;
		}
		set
		{
			bool isRunning = IsRunning;
			Stop();
			_elapsed = value;
			if (isRunning)
			{
				Start();
			}
		}
	}

	public bool IsRunning => _stopwatch.IsRunning;

	public Clock(bool autoStart = false)
	{
		if (autoStart)
		{
			Start();
		}
	}

	public void Start()
	{
		_stopwatch.Start();
	}

	public TimeSlice Pause()
	{
		_stopwatch.Stop();
		return ElapsedTime;
	}

	public TimeSlice Stop()
	{
		TimeSlice elapsedTime = ElapsedTime;
		_stopwatch.Reset();
		_elapsed = TimeSlice.Zero;
		return elapsedTime;
	}

	public TimeSlice Restart()
	{
		TimeSlice elapsedTime = ElapsedTime;
		_stopwatch.Restart();
		_elapsed = TimeSlice.Zero;
		return elapsedTime;
	}
}
