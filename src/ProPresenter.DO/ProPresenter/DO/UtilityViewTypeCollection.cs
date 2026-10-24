using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace ProPresenter.DO;

public class UtilityViewTypeCollection : ImmutableObservableCollection<UtilityViewType>, IDragDropCollection<UtilityViewType>
{
	public UtilityViewTypeCollection(IEnumerable<UtilityViewType> availableViewTypes)
		: base(availableViewTypes)
	{
	}

	public void DraggedFrom(IEnumerable<UtilityViewType> items)
	{
	}

	public void DroppedInto(IEnumerable<UtilityViewType> items, int index, bool isCopy)
	{
	}

	public void MoveTo(IEnumerable<UtilityViewType> items, int index)
	{
		base.Collection.MoveTo(items, index);
	}

	public void Reset(List<UtilityViewType> utilityViewTabs)
	{
		base.Collection.RemoveRange(base.Collection.ToArray());
		base.Collection.AddRange(utilityViewTabs.ToArray());
	}
}
