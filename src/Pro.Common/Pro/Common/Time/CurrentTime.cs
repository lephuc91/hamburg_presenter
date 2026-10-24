using System;

namespace Pro.Common.Time;

public class CurrentTime : ICurrentTime
{
	public DateTime Now => DateTime.Now;

	public DateTime UtcNow => DateTime.UtcNow;

	public DateTime Today => DateTime.Today;
}
