using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class FloatCollection : ValueCollection<float>
{
	public FloatCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<float, LoroValue>)Serialize, (Func<ValueOrContainer?, float>)Deserialize)
	{
	}

	private static LoroValue Serialize(float value)
	{
		return value.ToLoroValue();
	}

	private static float Deserialize(ValueOrContainer? value)
	{
		return value.ToDouble().ToFloat();
	}
}
