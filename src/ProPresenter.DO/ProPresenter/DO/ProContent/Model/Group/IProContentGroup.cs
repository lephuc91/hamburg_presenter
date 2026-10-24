using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent.Model.Group;

public interface IProContentGroup : INotifyEnumerableChanged<IProContentCollection>, IEnumerable<IProContentCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
{
	string DisplayName { get; }

	string Icon { get; }

	string Id { get; }
}
