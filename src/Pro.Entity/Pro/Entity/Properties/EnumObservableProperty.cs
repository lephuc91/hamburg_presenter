using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class EnumObservableProperty<T> : ValueObservableProperty<T> where T : struct, Enum
{
	public EnumObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, T>)LoroValueExtensions.ToEnum<T>, (Func<T, LoroValue>)EnumExtensions.ToLoroValue)
	{
	}
}
