using System;

namespace Pro.Common.Time;

public interface ICurrentTimeOffset
{
	DateTimeOffset Now { get; }

	DateTimeOffset UtcNow { get; }
}
