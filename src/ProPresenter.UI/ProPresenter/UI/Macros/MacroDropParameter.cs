using System.Collections;
using System.Windows;

namespace ProPresenter.UI.Macros;

public class MacroDropParameter
{
	public IEnumerable DroppedItems { get; }

	public FrameworkElement? Target { get; }

	public bool DropBefore { get; }

	public bool DropOutside { get; }

	public MacroDropParameter(IEnumerable droppedItems, FrameworkElement? target, bool dropBefore, bool dropOutside)
	{
		DroppedItems = droppedItems;
		Target = target;
		DropBefore = dropBefore;
		DropOutside = dropOutside;
	}
}
