namespace ProPresenter.DO.Analytics;

public interface ITimecodeAnalyticsEvents
{
	void Activate(int playlistItemCount, int cueCount, bool isStartup);

	void Startup(bool isConfigured, bool isEnabled, bool isPlaylistSelected);
}
