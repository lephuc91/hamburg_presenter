using System.Collections;
using System.IO;
using Pro.Common.Time;

namespace ProPresenter.UI.Controls;

public class FileTimelineItemDropArgs : ITimelineItemDropArgs
{
	public TimeSlice DropTime { get; }

	public FileInfo[] Files { get; }

	public IEnumerable DroppedItems { get; }

	public FileTimelineItemDropArgs(TimeSlice dropTime, FileInfo[] files)
	{
		DropTime = dropTime;
		Files = files;
		DroppedItems = files;
	}
}
