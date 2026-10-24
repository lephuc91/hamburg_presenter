using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalFloatObservableProperty : ValueObservableProperty<float?>
{
	public OptionalFloatObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, float?>)Deserialize, (Func<float?, LoroValue>)FloatExtensions.ToLoroValue)
	{
	}

	public static float? Deserialize(LoroValue? value)
	{
		return value.ToNullableDouble()?.ToFloat();
	}
}
