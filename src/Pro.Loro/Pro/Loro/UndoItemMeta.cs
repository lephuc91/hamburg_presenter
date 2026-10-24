using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record UndoItemMeta(LoroValue value, List<CursorWithPos> cursors) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(value, cursors);
	}
}
