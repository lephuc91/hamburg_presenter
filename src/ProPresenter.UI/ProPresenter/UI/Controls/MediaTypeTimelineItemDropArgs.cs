using System;
using System.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.Controls;

public class MediaTypeTimelineItemDropArgs : ITimelineItemDropArgs
{
	public TimeSlice DropTime { get; }

	public MediaType[] MediaTypes { get; }

	public Func<ActionBase>? GetAction { get; set; }

	public IEnumerable DroppedItems { get; }

	public MediaTypeTimelineItemDropArgs(TimeSlice dropTime, MediaType[] mediaTypes)
	{
		DropTime = dropTime;
		MediaTypes = mediaTypes;
		DroppedItems = mediaTypes;
	}
}
