using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class GuidObservableProperty : ValueObservableProperty<Guid>
{
	public GuidObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, Guid>)LoroValueExtensions.ToGuidValue, (Func<Guid, LoroValue>)GuidExtensions.ToLoroValue)
	{
	}
}
