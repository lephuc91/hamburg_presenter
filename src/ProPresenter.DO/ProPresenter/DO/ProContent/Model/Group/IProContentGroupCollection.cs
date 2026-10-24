using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.ProContent.Model.Group;

public interface IProContentGroupCollection : INotifyEnumerableChanged<IProContentGroup>, IEnumerable<IProContentGroup>, IEnumerable, INotifyCollectionChanged
{
	void Add(IProContentGroup group);

	void Clear();
}
