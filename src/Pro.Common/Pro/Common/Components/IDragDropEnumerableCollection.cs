using System.Collections;
using System.Collections.Generic;

namespace Pro.Common.Components;

public interface IDragDropEnumerableCollection<T> : IDragDropCollection<T>, IEnumerable<T>, IEnumerable
{
}
