using System;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class AtomicMapCollection<T> : ValueCollection<T> where T : notnull
{
	public AtomicMapCollection(LoroMap containingMap, string key, IAtomicValueFactory<T> factory, Func<T, LoroValue> serialize)
		: base(containingMap, key, serialize, (Func<ValueOrContainer?, T>)((ValueOrContainer? value) => Deserialize(value, factory)))
	{
	}

	private static T Deserialize(ValueOrContainer? value, IAtomicValueFactory<T> factory)
	{
		if (value?.AsValue() is LoroValue.Map map)
		{
			return factory.CreateInstance(map.value);
		}
		return factory.CreateInstance();
	}
}
