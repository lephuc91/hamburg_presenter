using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class StringObservableProperty : ValueObservableProperty<string>
{
	public StringObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, string>)LoroValueExtensions.ToStringValue, (Func<string, LoroValue>)StringExtensions.ToLoroValue)
	{
	}
}
