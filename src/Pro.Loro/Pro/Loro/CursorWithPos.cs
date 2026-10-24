using System;

namespace Pro.Loro;

public record CursorWithPos(Cursor cursor, AbsolutePosition pos) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(cursor, pos);
	}
}
