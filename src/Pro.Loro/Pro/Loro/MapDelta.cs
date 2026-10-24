using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record MapDelta(Dictionary<string, ValueOrContainer?> updated) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(updated);
	}
}
