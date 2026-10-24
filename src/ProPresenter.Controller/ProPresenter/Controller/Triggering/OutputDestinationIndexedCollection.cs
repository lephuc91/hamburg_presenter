using System;
using System.Collections;
using System.Collections.Generic;
using ProPresenter.DO;

namespace ProPresenter.Controller.Triggering;

public abstract class OutputDestinationIndexedCollection<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
{
	protected T[] Items { get; }

	public T this[OutputDestination index] => Items[(int)index];

	public int Count { get; } = Enum.GetValues<OutputDestination>().Length;

	protected OutputDestinationIndexedCollection()
	{
		Items = new T[Count];
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ((IEnumerable<T>)Items).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Items.GetEnumerator();
	}
}
