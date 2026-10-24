using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class ULongObservableProperty : ValueObservableProperty<ulong>
{
	public ULongObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, ulong>)Deserialize, (Func<ulong, LoroValue>)ULongExtensions.ToLoroValue)
	{
	}

	private static ulong Deserialize(LoroValue? value)
	{
		return value.ToLong().ToUlong();
	}
}
