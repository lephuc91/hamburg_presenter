using System.Collections.Generic;

namespace ProPresenter.UI.Thumbnails;

public class DragDropCommandParameters<T, I> : IDragDropCommandParameters<T, I>
{
	public I? Source { get; }

	public IEnumerable<T>? Items { get; }

	public T? TargetItem { get; }

	public int DropIndex { get; }

	public bool DroppedBefore { get; }

	public bool DroppedOutside { get; }

	public bool Copy { get; }

	public DragDropCommandParameters(I? source, IEnumerable<T>? items, T? targetItem, int dropIndex, bool droppedBefore, bool droppedOutside, bool copy)
	{
		Source = source;
		Items = items;
		TargetItem = targetItem;
		DropIndex = dropIndex;
		DroppedBefore = droppedBefore;
		DroppedOutside = droppedOutside;
		Copy = copy;
	}
}
