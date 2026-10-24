using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent.Model.Group;

public interface IInternalProContentSearchGroup : IInternalProContentGroup, IProContentGroup, INotifyEnumerableChanged<IProContentCollection>, IEnumerable<IProContentCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IProContentSearchGroup
{
}
