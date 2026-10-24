using System;
using System.Collections.Generic;

namespace Pro.Entity.Collections;

public interface ICollection<T>
{
	IObservable<IReadOnlyList<T>> WhenCollectionChanges { get; }

	IReadOnlyList<T> Items { get; }

	void Add(T item);

	void AddRange(IEnumerable<T> items);

	void Insert(int index, T item);

	void Replace(int index, T item);

	void RemoveAt(int index);

	void Move(int fromIndex, int toIndex);

	void MoveMany(int fromIndex, int numberOfItemsToMove, int toIndex);

	void Clear();

	void Reset(IEnumerable<T> items);
}
