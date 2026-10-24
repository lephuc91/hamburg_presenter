namespace ProPresenter.DO.Analytics;

public class TimecodeAnalyticsEvents : ITimecodeAnalyticsEvents
{
	public void Activate(int playlistItemCount, int cueCount, bool isStartup)
	{
		TimecodeActivateEvent.Publish(playlistItemCount, cueCount, isStartup);
	}

	public void Startup(bool isConfigured, bool isEnabled, bool isPlaylistSelected)
	{
		TimecodeStartupEvent.Publish(isConfigured, isEnabled, isPlaylistSelected);
	}
}
