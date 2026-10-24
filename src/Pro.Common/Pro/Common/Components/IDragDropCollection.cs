using System.Collections.Generic;

namespace Pro.Common.Components;

public interface IDragDropCollection<T>
{
	int IndexOf(T item);

	void DraggedFrom(IEnumerable<T> items);

	void DroppedInto(IEnumerable<T> items, int index, bool isCopy);

	void MoveTo(IEnumerable<T> items, int index);
}
