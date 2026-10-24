using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalEnumObservableProperty<T> : ValueObservableProperty<T?> where T : struct, Enum
{
	public OptionalEnumObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, T?>)LoroValueExtensions.ToNullableEnum<T>, (Func<T?, LoroValue>)EnumExtensions.ToLoroValue)
	{
	}
}
