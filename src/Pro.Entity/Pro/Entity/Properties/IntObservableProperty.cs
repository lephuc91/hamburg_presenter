using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class IntObservableProperty : ValueObservableProperty<int>
{
	public IntObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, int>)ToInt32, (Func<int, LoroValue>)IntExtensions.ToLoroValue)
	{
	}

	private static int ToInt32(LoroValue? value)
	{
		return value.ToLong().ToInt();
	}
}
