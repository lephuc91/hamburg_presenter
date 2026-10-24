using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record ListDiffItem : IDisposable
{
	public record Insert(List<ValueOrContainer> insert, bool isMove) : ListDiffItem();

	public record Delete(uint delete) : ListDiffItem();

	public record Retain(uint retain) : ListDiffItem();

	public void Dispose()
	{
		if (!(this is Insert insert))
		{
			if (!(this is Delete delete))
			{
				if (!(this is Retain retain))
				{
					throw new InternalException($"invalid enum value '{this}' in ListDiffItem.Dispose()");
				}
				FFIObjectUtil.DisposeAll(retain.retain);
			}
			else
			{
				FFIObjectUtil.DisposeAll(delete.delete);
			}
		}
		else
		{
			FFIObjectUtil.DisposeAll(insert.insert, insert.isMove);
		}
	}
}
