using Pro.Common.Time;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.ViewModels.Timeline;

public interface ITimelineItemVMFactory
{
	ITimelineItemVM CreateItemVM(TimelineItemInfo timelineInfo, TimelineItemNamePattern timeline);

	ITimeTickSection CreateTickSection(TimeSlice startTime, TimeSlice duration);
}
