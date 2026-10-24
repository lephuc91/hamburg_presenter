using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class IntCollection : ValueCollection<int>
{
	public IntCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<int, LoroValue>)Serialize, (Func<ValueOrContainer?, int>)Deserialize)
	{
	}

	private static LoroValue Serialize(int value)
	{
		return LongExtensions.ToLoroValue(value);
	}

	private static int Deserialize(ValueOrContainer? value)
	{
		return (int)value.ToLong();
	}
}
