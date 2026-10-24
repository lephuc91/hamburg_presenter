using System;

namespace Pro.CoreApplication.Workspace;

public record PausedSync(DateTimeOffset Until, DateTimeOffset At) : ISyncStatus
{
	public bool IsPaused => true;
}
