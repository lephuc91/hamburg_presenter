using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Pro.Common.Collections;

public class NotifyObservableCollection<T> : ObservableCollection<T>, INotifyEnumerableChanged<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged
{
}
