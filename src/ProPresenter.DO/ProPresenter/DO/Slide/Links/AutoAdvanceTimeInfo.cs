using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public class AutoAdvanceTimeInfo : IAutoAdvanceTimeInfo
{
	public TimeSlice? Presentation { get; }

	public TimeSlice? Announcement { get; }

	public AutoAdvanceTimeInfo(TimeSlice? presentation, TimeSlice? announcement)
	{
		Presentation = presentation;
		Announcement = announcement;
	}
}
