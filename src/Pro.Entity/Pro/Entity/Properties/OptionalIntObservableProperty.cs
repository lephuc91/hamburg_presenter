using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalIntObservableProperty : ValueObservableProperty<int?>
{
	public OptionalIntObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, int?>)Deserialize, (Func<int?, LoroValue>)IntExtensions.ToLoroValue)
	{
	}

	public static int? Deserialize(LoroValue? value)
	{
		return value.ToNullableLong()?.ToInt();
	}
}
