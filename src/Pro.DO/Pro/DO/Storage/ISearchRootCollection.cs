using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace Pro.DO.Storage;

public interface ISearchRootCollection : IDragDropNotifyEnumerableChanged<ISearchRoot>, INotifyEnumerableChanged<ISearchRoot>, IEnumerable<ISearchRoot>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ISearchRoot>
{
	event Action DataModified;
}
