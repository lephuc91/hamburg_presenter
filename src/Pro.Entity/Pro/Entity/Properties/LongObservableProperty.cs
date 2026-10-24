using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class LongObservableProperty : ValueObservableProperty<long>
{
	public LongObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, long>)LoroValueExtensions.ToLong, (Func<long, LoroValue>)LongExtensions.ToLoroValue)
	{
	}
}
