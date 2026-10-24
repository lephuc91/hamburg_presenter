using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pro.Common.Collections;

public interface INotifyEnumerableChanged<out I> : IEnumerable<I>, IEnumerable, INotifyCollectionChanged
{
}
