using System.Collections;
using Pro.Common.Time;

namespace ProPresenter.UI.Controls;

public interface ITimelineItemDropArgs
{
	TimeSlice DropTime { get; }

	IEnumerable DroppedItems { get; }
}
