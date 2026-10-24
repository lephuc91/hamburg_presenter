using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class UintObservableProperty : ValueObservableProperty<uint>
{
	public UintObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, uint>)Deserialize, (Func<uint, LoroValue>)UIntExtensions.ToLoroValue)
	{
	}

	private static uint Deserialize(LoroValue? value)
	{
		return value.ToLong().ToUint();
	}
}
