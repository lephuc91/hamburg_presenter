using System;
using System.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;

namespace ProPresenter.UI.Controls;

public class ActionTypeTimelineItemDropArgs : ITimelineItemDropArgs
{
	public TimeSlice DropTime { get; }

	public ActionType[] ActionTypes { get; }

	public Func<IAction>? GetAction { get; set; }

	public IEnumerable DroppedItems { get; }

	public ActionTypeTimelineItemDropArgs(TimeSlice dropTime, ActionType[] actionTypes)
	{
		DropTime = dropTime;
		ActionTypes = actionTypes;
		DroppedItems = actionTypes;
	}
}
