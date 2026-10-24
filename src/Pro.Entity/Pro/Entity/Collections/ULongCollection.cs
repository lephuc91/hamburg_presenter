using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class ULongCollection : ValueCollection<ulong>
{
	public ULongCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<ulong, LoroValue>)Serialize, (Func<ValueOrContainer?, ulong>)Deserialize)
	{
	}

	private static LoroValue Serialize(ulong value)
	{
		return ((long)value).ToLoroValue();
	}

	private static ulong Deserialize(ValueOrContainer? value)
	{
		return (ulong)value.ToLong();
	}
}
