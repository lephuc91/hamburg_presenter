using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalDoubleObservableProperty : ValueObservableProperty<double?>
{
	public OptionalDoubleObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, double?>)LoroValueExtensions.ToNullableDouble, (Func<double?, LoroValue>)DoubleExtensions.ToLoroValue)
	{
	}
}
