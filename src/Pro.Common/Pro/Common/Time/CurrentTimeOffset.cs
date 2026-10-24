using System;

namespace Pro.Common.Time;

public class CurrentTimeOffset : ICurrentTimeOffset
{
	public DateTimeOffset Now => DateTimeOffset.Now;

	public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
