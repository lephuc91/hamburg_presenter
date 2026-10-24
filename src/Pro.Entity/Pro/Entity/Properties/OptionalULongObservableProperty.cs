using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalULongObservableProperty : ValueObservableProperty<ulong?>
{
	public OptionalULongObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, ulong?>)Deserialize, (Func<ulong?, LoroValue>)ULongExtensions.ToLoroValue)
	{
	}

	public static ulong? Deserialize(LoroValue? value)
	{
		return value.ToNullableLong()?.ToUlong();
	}
}
