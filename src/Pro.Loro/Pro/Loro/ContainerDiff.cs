using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record ContainerDiff(ContainerId target, List<PathItem> path, bool isUnknown, Diff diff) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(target, path, isUnknown, diff);
	}
}
