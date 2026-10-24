using System;
using System.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;

namespace ProPresenter.UI.Controls;

public class TriggerableTimelineItemDropArgs : ITimelineItemDropArgs
{
	public TimeSlice DropTime { get; }

	public ITriggerable[] Triggerables { get; }

	public Func<IAction>? GetAction { get; set; }

	public IEnumerable DroppedItems { get; }

	public TriggerableTimelineItemDropArgs(TimeSlice dropTime, ITriggerable[] triggerables)
	{
		DropTime = dropTime;
		Triggerables = triggerables;
		DroppedItems = triggerables;
	}
}
