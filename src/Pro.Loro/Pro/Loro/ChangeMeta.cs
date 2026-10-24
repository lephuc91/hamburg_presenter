using System;

namespace Pro.Loro;

public record ChangeMeta(uint lamport, Id id, long timestamp, string? message, Frontiers deps, uint len) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(lamport, id, timestamp, message, deps, len);
	}
}
