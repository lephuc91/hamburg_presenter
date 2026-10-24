using System;
using System.Diagnostics;

namespace Pro.Common.Concurrency;

public class Stopwatch : IStopwatch
{
	private readonly System.Diagnostics.Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

	public TimeSpan Elapsed => _stopwatch.Elapsed;

	public void Restart()
	{
		_stopwatch.Restart();
	}
}
