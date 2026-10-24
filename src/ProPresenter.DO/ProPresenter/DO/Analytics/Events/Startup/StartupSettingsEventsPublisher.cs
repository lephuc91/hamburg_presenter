using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.Startup;

public class StartupSettingsEventsPublisher : IStartupSettingsEventsPublisher
{
	public void StartupPreferences(bool houseOfWorship, bool customLogo, bool copyrightEnabled, CopyRightStyleValue copyrightStyle, bool copyrightHasLicense, RenderModeValue renderMode, bool suppressAutoStart, bool manageMediaAutomatically, bool searchPathsRelink, UpdateChannelValue updateChannel)
	{
		EventPublisher.Publish(new StartupSettingsEvent(houseOfWorship, customLogo, copyrightEnabled, copyrightStyle, copyrightHasLicense, renderMode, suppressAutoStart, manageMediaAutomatically, searchPathsRelink, updateChannel));
	}
}
