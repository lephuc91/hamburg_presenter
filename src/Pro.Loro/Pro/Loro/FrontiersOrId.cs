using System;

namespace Pro.Loro;

public record FrontiersOrId(Frontiers? frontiers, Id? id) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(frontiers, id);
	}
}
