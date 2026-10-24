using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public interface IAutoAdvanceTimeInfo
{
	TimeSlice? Announcement { get; }

	TimeSlice? Presentation { get; }
}
