using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class FloatObservableProperty : ValueObservableProperty<float>
{
	public FloatObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, float>)ToFloat, (Func<float, LoroValue>)FloatExtensions.ToLoroValue)
	{
	}

	private static float ToFloat(LoroValue? value)
	{
		return value.ToDouble().ToFloat();
	}
}
