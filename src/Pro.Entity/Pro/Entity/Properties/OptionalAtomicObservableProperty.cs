using System;
using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalAtomicObservableProperty<T> : ValueObservableProperty<T?> where T : class
{
	public OptionalAtomicObservableProperty(string key, LoroMap map, Func<Dictionary<string, LoroValue>, T> deserialize, Func<T, LoroValue> serialize)
		: base(key, map, (Func<LoroValue?, T>)((LoroValue? v) => v.TryDeserialize(deserialize)), (Func<T, LoroValue>)((T? v) => (v == null) ? new LoroValue.Null() : serialize(v)))
	{
	}
}
