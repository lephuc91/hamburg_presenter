namespace ProPresenter.DO.Analytics.Events.Welcome;

public interface IWelcomeAnalyticEventsPublisher
{
	void Shown(WelcomeToProPresenterLaunchLocation launchLocation);

	void MigrationExecuted();

	void ScreenConfigurationHelp();

	void DownloadSampleContent();

	void UserGroupViewed();

	void TutorialsViewedEvent();

	void KnowledgeBaseViewedEvent();

	void BlogViewedEvent();

	void InstagramViewedEvent();

	void FacebookViewedEvent();
}
