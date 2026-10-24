namespace Pro.Common.Concurrency;

public class StopwatchFactory : IStopwatchFactory
{
	public IStopwatch Create()
	{
		return new Stopwatch();
	}
}
