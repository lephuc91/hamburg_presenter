using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class BoolCollection : ValueCollection<bool>
{
	public BoolCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<bool, LoroValue>)Serialize, (Func<ValueOrContainer?, bool>)Deserialize)
	{
	}

	private static LoroValue Serialize(bool value)
	{
		return value.ToLoroValue();
	}

	private static bool Deserialize(ValueOrContainer? value)
	{
		return value.ToBool();
	}
}
