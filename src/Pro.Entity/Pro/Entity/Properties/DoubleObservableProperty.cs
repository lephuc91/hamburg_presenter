using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class DoubleObservableProperty : ValueObservableProperty<double>
{
	public DoubleObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, double>)LoroValueExtensions.ToDouble, (Func<double, LoroValue>)DoubleExtensions.ToLoroValue)
	{
	}
}
