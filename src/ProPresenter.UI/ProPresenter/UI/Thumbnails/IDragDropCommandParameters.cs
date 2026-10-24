using System.Collections.Generic;

namespace ProPresenter.UI.Thumbnails;

public interface IDragDropCommandParameters<out T, out I>
{
	bool Copy { get; }

	int DropIndex { get; }

	bool DroppedBefore { get; }

	bool DroppedOutside { get; }

	IEnumerable<T>? Items { get; }

	I? Source { get; }

	T? TargetItem { get; }
}
