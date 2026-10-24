using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class UIntCollection : ValueCollection<uint>
{
	public UIntCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<uint, LoroValue>)Serialize, (Func<ValueOrContainer?, uint>)Deserialize)
	{
	}

	private static LoroValue Serialize(uint value)
	{
		return LongExtensions.ToLoroValue(value);
	}

	private static uint Deserialize(ValueOrContainer? value)
	{
		return (uint)value.ToLong();
	}
}
