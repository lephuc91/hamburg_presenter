using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace Pro.DO.Storage;

public class SearchRootCollection : ImmutableObservableCollection<ISearchRoot>, ISearchRootCollection, IDragDropNotifyEnumerableChanged<ISearchRoot>, INotifyEnumerableChanged<ISearchRoot>, IEnumerable<ISearchRoot>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ISearchRoot>
{
	public event Action? DataModified;

	public SearchRootCollection()
	{
		Enum.GetValues<SearchRootType>().ForEach(delegate(SearchRootType t)
		{
			base.Collection.Add(new SearchRoot(t));
		});
		this.ForEach(delegate(ISearchRoot r)
		{
			r.PropertyChanged += delegate
			{
				this.DataModified?.Invoke();
			};
		});
	}

	public void DraggedFrom(IEnumerable<ISearchRoot> items)
	{
		throw new NotSupportedException();
	}

	public void DroppedInto(IEnumerable<ISearchRoot> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	public void MoveTo(IEnumerable<ISearchRoot> items, int index)
	{
		base.Collection.MoveTo(items, index);
		this.DataModified?.Invoke();
	}
}
