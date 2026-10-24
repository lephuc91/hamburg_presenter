namespace ProPresenter.DO.Analytics.Events.Startup;

public interface IStartupSettingsEventsPublisher
{
	void StartupPreferences(bool houseOfWorship, bool customLogo, bool copyrightEnabled, CopyRightStyleValue copyrightStyle, bool copyrightHasLicense, RenderModeValue renderMode, bool suppressAutoStart, bool manageMediaAutomatically, bool searchPathsRelink, UpdateChannelValue updateChannel);
}
