using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class LongCollection : ValueCollection<long>
{
	public LongCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<long, LoroValue>)Serialize, (Func<ValueOrContainer?, long>)Deserialize)
	{
	}

	private static LoroValue Serialize(long value)
	{
		return value.ToLoroValue();
	}

	private static long Deserialize(ValueOrContainer? value)
	{
		return value.ToLong();
	}
}
