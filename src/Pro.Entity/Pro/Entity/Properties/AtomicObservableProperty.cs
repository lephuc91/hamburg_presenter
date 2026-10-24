using System;
using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class AtomicObservableProperty<T> : ValueObservableProperty<T> where T : notnull
{
	public AtomicObservableProperty(string key, LoroMap map, Func<Dictionary<string, LoroValue>, T> deserialize, Func<T, LoroValue> serialize)
		: base(key, map, (Func<LoroValue?, T>)((LoroValue? v) => deserialize(v.ToDictionary())), serialize)
	{
	}
}
