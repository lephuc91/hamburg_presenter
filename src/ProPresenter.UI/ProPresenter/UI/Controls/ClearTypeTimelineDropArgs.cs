using System.Collections;
using Pro.Common.Time;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.Controls;

public class ClearTypeTimelineDropArgs : ITimelineItemDropArgs
{
	public TimeSlice DropTime { get; }

	public ClearType[] ClearTypes { get; }

	public IEnumerable DroppedItems { get; }

	public ClearTypeTimelineDropArgs(TimeSlice dropTime, ClearType[] clearTypes)
	{
		DropTime = dropTime;
		ClearTypes = clearTypes;
		DroppedItems = clearTypes;
	}
}
