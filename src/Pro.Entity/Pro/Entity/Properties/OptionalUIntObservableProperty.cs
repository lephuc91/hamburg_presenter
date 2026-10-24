using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalUIntObservableProperty : ValueObservableProperty<uint?>
{
	public OptionalUIntObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, uint?>)Deserialize, (Func<uint?, LoroValue>)UIntExtensions.ToLoroValue)
	{
	}

	public static uint? Deserialize(LoroValue? value)
	{
		return value.ToNullableLong()?.ToUint();
	}
}
