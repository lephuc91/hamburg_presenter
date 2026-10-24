using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Pro.Common.Collections;

public sealed class EmptyNotifyEnumerableChanged<T> : INotifyEnumerableChanged<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged
{
	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public IEnumerator<T> GetEnumerator()
	{
		return Enumerable.Empty<T>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
