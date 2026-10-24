using System;
using System.Collections.Generic;
using System.Reactive;
using Pro.Entity.Collections;

namespace Pro.Entity.Merged.Collections;

public interface IMergedCollection<T> : Pro.Entity.Collections.ICollection<T>, IDisposable
{
	IObservable<Unit> WhenAnyValueChanges { get; }

	void SynchronizeFrom<TSource>(IEnumerable<TSource> source, Func<TSource, T, bool> equal, Func<TSource, T> create);
}
