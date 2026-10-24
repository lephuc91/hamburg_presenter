using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public struct CountdownData
{
	public TimeSlice TimeRemaining { get; set; }

	public bool IsLooping { get; set; }

	public CountdownData(TimeSlice timeRemaining, bool isLooping)
	{
		TimeRemaining = timeRemaining;
		IsLooping = isLooping;
	}
}
