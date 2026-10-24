using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalStringObservableProperty : ValueObservableProperty<string?>
{
	public OptionalStringObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, string>)LoroValueExtensions.ToNullableStringValue, (Func<string, LoroValue>)StringExtensions.ToLoroValue)
	{
	}
}
