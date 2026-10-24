using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class EnumCollection<T> : ValueCollection<T> where T : struct, Enum
{
	public EnumCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<T, LoroValue>)Serialize, (Func<ValueOrContainer?, T>)Deserialize)
	{
	}

	private static LoroValue Serialize(T value)
	{
		return value.ToLoroValue();
	}

	private static T Deserialize(ValueOrContainer? value)
	{
		return value.ToEnum<T>();
	}
}
