using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent.Model.Group;

public interface IInternalProContentGroup : IProContentGroup, INotifyEnumerableChanged<IProContentCollection>, IEnumerable<IProContentCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
{
	new string DisplayName { get; set; }

	new string Icon { get; set; }

	void Clear();

	void Add(IProContentCollection collection);
}
