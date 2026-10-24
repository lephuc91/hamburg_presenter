namespace ProPresenter.DO.Analytics;

public class PlaybackMarkerAnalyticsEvents : IPlaybackMarkerAnalyticsEvents
{
	public void Create(PlaybackMarkerCreateLocation location)
	{
		PlaybackMarkerCreateEvent.Publish(location);
	}
}
