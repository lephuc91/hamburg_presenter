using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pro.Common.Collections;

[CollectionBuilder(typeof(DisposableCollection), "Create")]
public sealed class DisposableCollection([ParamCollection] IReadOnlyList<IDisposable> disposables) : IDisposable, IReadOnlyList<IDisposable>, IEnumerable<IDisposable>, IEnumerable, IReadOnlyCollection<IDisposable>
{
	public IDisposable this[int index] => disposables[index];

	public int Count => disposables.Count;

	public void Dispose()
	{
		foreach (IDisposable item in disposables)
		{
			item.Dispose();
		}
	}

	public IEnumerator<IDisposable> GetEnumerator()
	{
		return disposables.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return disposables.GetEnumerator();
	}

	public static DisposableCollection Create(ReadOnlySpan<IDisposable> disposables)
	{
		return new DisposableCollection(new global::_003C_003Ez__ReadOnlyArray<IDisposable>(disposables.ToArray()));
	}
}
