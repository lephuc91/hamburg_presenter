using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public interface IDragDropNotifyEnumerableChanged<I> : INotifyEnumerableChanged<I>, IEnumerable<I>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<I>
{
}
