using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pro.Common.Collections;

public interface IImmutableObservableCollection<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, INotifyEnumerableChanged<T>, INotifyCollectionChanged
{
	int IndexOf(T item);

	bool Contains(T value);
}
