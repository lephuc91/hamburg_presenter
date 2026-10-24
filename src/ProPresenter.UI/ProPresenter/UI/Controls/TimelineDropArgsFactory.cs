using System;
using System.IO;
using Pro.Common.Time;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.Controls;

public class TimelineDropArgsFactory
{
	public ITimelineItemDropArgs? Create<T>(TimeSlice dropTime, T[] dropArgs)
	{
		Type typeFromHandle = typeof(T);
		if (typeFromHandle == typeof(ITriggerable) || typeFromHandle.IsAssignableTo(typeof(ITriggerable)))
		{
			return new TriggerableTimelineItemDropArgs(dropTime, dropArgs as ITriggerable[]);
		}
		if (typeFromHandle == typeof(MediaType))
		{
			return new MediaTypeTimelineItemDropArgs(dropTime, dropArgs as MediaType[]);
		}
		if (typeFromHandle == typeof(ActionType))
		{
			return new ActionTypeTimelineItemDropArgs(dropTime, dropArgs as ActionType[]);
		}
		if (typeFromHandle == typeof(ClearType))
		{
			return new ClearTypeTimelineDropArgs(dropTime, dropArgs as ClearType[]);
		}
		if (typeFromHandle == typeof(FileInfo))
		{
			return new FileTimelineItemDropArgs(dropTime, dropArgs as FileInfo[]);
		}
		return null;
	}
}
