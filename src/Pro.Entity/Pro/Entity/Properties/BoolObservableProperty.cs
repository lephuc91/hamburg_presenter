using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class BoolObservableProperty : ValueObservableProperty<bool>
{
	public BoolObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, bool>)LoroValueExtensions.ToBool, (Func<bool, LoroValue>)BoolExtensions.ToLoroValue)
	{
	}
}
