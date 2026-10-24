using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalBoolObservableProperty : ValueObservableProperty<bool?>
{
	public OptionalBoolObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, bool?>)LoroValueExtensions.ToNullableBool, (Func<bool?, LoroValue>)BoolExtensions.ToLoroValue)
	{
	}
}
