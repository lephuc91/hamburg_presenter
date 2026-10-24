using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.ProContent.Model.Group;

public class ProContentGroupCollection : ObservableCollection<IProContentGroup>, IProContentGroupCollection, INotifyEnumerableChanged<IProContentGroup>, IEnumerable<IProContentGroup>, IEnumerable, INotifyCollectionChanged
{
}
