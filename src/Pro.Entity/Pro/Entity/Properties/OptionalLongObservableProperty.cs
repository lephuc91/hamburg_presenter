using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalLongObservableProperty : ValueObservableProperty<long?>
{
	public OptionalLongObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, long?>)LoroValueExtensions.ToNullableLong, (Func<long?, LoroValue>)LongExtensions.ToLoroValue)
	{
	}
}
