using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class DoubleCollection : ValueCollection<double>
{
	public DoubleCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<double, LoroValue>)Serialize, (Func<ValueOrContainer?, double>)Deserialize)
	{
	}

	private static LoroValue Serialize(double value)
	{
		return value.ToLoroValue();
	}

	private static double Deserialize(ValueOrContainer? value)
	{
		return value.ToDouble();
	}
}
