using System;

namespace Pro.Loro;

public record PosQueryResult(Cursor? update, AbsolutePosition current) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(update, current);
	}
}
