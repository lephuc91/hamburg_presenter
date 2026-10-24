using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public class CountdownInfo : ICountdownInfo
{
	public CountdownData Presentation { get; set; }

	public CountdownData Announcement { get; set; }

	public CountdownData Audio { get; set; }

	public CountdownInfo()
	{
	}

	public CountdownInfo(TimeSlice presentation, bool presentationIsLooping, TimeSlice announcement, bool announcementIsLooping, TimeSlice audio, bool audioIsLooping)
	{
		Presentation = new CountdownData(presentation, presentationIsLooping);
		Announcement = new CountdownData(announcement, announcementIsLooping);
		Audio = new CountdownData(audio, audioIsLooping);
	}
}
