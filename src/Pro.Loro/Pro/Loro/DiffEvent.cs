using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record DiffEvent(EventTriggerKind triggeredBy, string origin, ContainerId? currentTarget, List<ContainerDiff> events) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(triggeredBy, origin, currentTarget, events);
	}
}
