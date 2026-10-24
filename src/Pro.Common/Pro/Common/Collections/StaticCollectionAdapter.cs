using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pro.Common.Collections;

public class StaticCollectionAdapter<I> : INotifyEnumerableChanged<I>, IEnumerable<I>, IEnumerable, INotifyCollectionChanged
{
	private readonly I[] _collection;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public StaticCollectionAdapter(I[] collection)
	{
		_collection = collection;
	}

	public IEnumerator<I> GetEnumerator()
	{
		return ((IEnumerable<I>)_collection).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _collection.GetEnumerator();
	}
}
