using System;

namespace Pro.Common.Time;

public interface ICurrentTime
{
	DateTime Now { get; }

	DateTime UtcNow { get; }

	DateTime Today { get; }
}
