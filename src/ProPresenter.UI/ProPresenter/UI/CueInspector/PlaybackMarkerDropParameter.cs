using System.Collections;
using System.Windows;

namespace ProPresenter.UI.CueInspector;

public class PlaybackMarkerDropParameter
{
	public IEnumerable DroppedItems { get; }

	public FrameworkElement? Target { get; }

	public bool DropBefore { get; }

	public bool DropOutside { get; }

	public PlaybackMarkerDropParameter(IEnumerable droppedItems, FrameworkElement? target, bool dropBefore, bool dropOutside)
	{
		DroppedItems = droppedItems;
		Target = target;
		DropBefore = dropBefore;
		DropOutside = dropOutside;
	}
}
