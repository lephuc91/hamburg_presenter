using System;

namespace Pro.Loro;

public record ContainerIdAndDiff(ContainerId cid, Diff diff) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(cid, diff);
	}
}
