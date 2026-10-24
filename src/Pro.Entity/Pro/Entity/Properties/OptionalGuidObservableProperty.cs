using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalGuidObservableProperty : ValueObservableProperty<Guid?>
{
	public OptionalGuidObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, Guid?>)LoroValueExtensions.ToNullableGuidValue, (Func<Guid?, LoroValue>)GuidExtensions.ToLoroValue)
	{
	}
}
