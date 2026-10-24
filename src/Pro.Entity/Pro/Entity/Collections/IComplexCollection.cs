using System;
using System.Collections.Generic;
using System.Reactive;

namespace Pro.Entity.Collections;

public interface IComplexCollection<T> : ICollection<T>
{
	public interface ISynchronizationScope : IDisposable
	{
	}

	IObservable<Unit> WhenAnyValueChanges { get; }

	ISynchronizationScope EnterSyncContext();

	void SynchronizeFrom<TSource>(IEnumerable<TSource> source, Func<TSource, T, bool> equal, Func<TSource, T> create);

	void ScopedInsert(int index, T item, ISynchronizationScope scope);

	void ScopedMove(int from, int to, ISynchronizationScope scope);

	void ScopedRemoveAt(int index, ISynchronizationScope scope);
}
