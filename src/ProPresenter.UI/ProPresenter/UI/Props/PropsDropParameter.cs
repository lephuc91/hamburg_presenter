using System.Collections;
using System.Windows;

namespace ProPresenter.UI.Props;

public class PropsDropParameter
{
	public IEnumerable DroppedItems { get; }

	public FrameworkElement? Target { get; }

	public int DropIndex { get; }

	public bool DropBefore { get; }

	public bool DropOutside { get; }

	public PropsDropParameter(IEnumerable droppedItems, int dropIndex, FrameworkElement? target, bool dropBefore, bool dropOutside)
	{
		DroppedItems = droppedItems;
		DropIndex = dropIndex;
		Target = target;
		DropBefore = dropBefore;
		DropOutside = dropOutside;
	}
}
