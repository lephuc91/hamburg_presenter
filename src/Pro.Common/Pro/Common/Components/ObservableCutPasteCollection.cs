using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pro.Common.Collections;

namespace Pro.Common.Components;

public class ObservableCutPasteCollection<T> : ObservableCollection<T>, ICutPasteCollection<T>, ICutCollection<T>
{
	public void CutFrom(IEnumerable<T> items)
	{
		this.RemoveRangeAndNotifyOnCompletion(items);
	}

	public void PasteInto(IEnumerable<T> items, int index)
	{
		this.InsertRange(index, items);
	}
}
