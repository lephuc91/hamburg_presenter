using Pro.Common.Components;

namespace Pro.UI;

public class DraggedTreeItemsCollection<T> where T : IDragDropTreeCollection<T>, IIdentifiable
{
	public DraggedTreeItems<T>[] DraggedTrees { get; }

	public DraggedTreeItemsCollection(DraggedTreeItems<T>[] draggedTrees)
	{
		DraggedTrees = draggedTrees;
	}
}
