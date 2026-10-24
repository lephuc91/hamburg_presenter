using System.Collections.Generic;
using Pro.Common.Collections;

namespace Pro.Common.Components;

public interface IDragDropTreeCollection<T> : ITreeNode<T> where T : IDragDropTreeCollection<T>, IIdentifiable
{
	T? Parent { get; }

	void DraggedFrom(IEnumerable<T> items);

	void DroppedInto(IEnumerable<T> items, int index, bool isCopy);

	void MoveTo(IEnumerable<T> items, int index);
}
