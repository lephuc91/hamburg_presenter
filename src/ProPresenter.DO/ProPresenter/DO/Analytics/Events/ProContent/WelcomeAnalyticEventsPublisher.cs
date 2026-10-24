using Pro.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Analytics.Events.Welcome.Events;

namespace ProPresenter.DO.Analytics.Events.ProContent;

public class WelcomeAnalyticEventsPublisher : IWelcomeAnalyticEventsPublisher
{
	public void BlogViewedEvent()
	{
		EventPublisher.Publish(new WelcomeDialogBlogViewedEvent());
	}

	public void DownloadSampleContent()
	{
		EventPublisher.Publish(new WelcomeDialogDownloadSampleContentEvent());
	}

	public void FacebookViewedEvent()
	{
		EventPublisher.Publish(new WelcomeDialogFacebookViewedEvent());
	}

	public void InstagramViewedEvent()
	{
		EventPublisher.Publish(new WelcomeDialogInstagramViewedEvent());
	}

	public void KnowledgeBaseViewedEvent()
	{
		EventPublisher.Publish(new WelcomeDialogKnowledgeBaseViewedEvent());
	}

	public void MigrationExecuted()
	{
		EventPublisher.Publish(new WelcomeDialogMigrationEvent());
	}

	public void ScreenConfigurationHelp()
	{
		EventPublisher.Publish(new WelcomeDialogScreenConfigurationHelpViewedEvent());
	}

	public void Shown(WelcomeToProPresenterLaunchLocation launchLocation)
	{
		EventPublisher.Publish(new WelcomeDialogShownEvent(launchLocation));
	}

	public void TutorialsViewedEvent()
	{
		EventPublisher.Publish(new WelcomeDialogTutorialsViewedEvent());
	}

	public void UserGroupViewed()
	{
		EventPublisher.Publish(new WelcomeDialogUserGroupViewedEvent());
	}
}
