using System;
using System.Collections.Generic;
using System.Reactive;

namespace Pro.Entity.Collections;

public interface IKeyedCollection<TKey, TValue> : IDisposable
{
	IObservable<IReadOnlyDictionary<TKey, TValue>> WhenCollectionChanges { get; }

	IObservable<Unit> WhenAnyValueChanges { get; }

	IReadOnlyDictionary<TKey, TValue> Items { get; }

	void Add(TKey key, TValue item);

	void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items);

	void Remove(TKey key);

	void Clear();
}
