using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.Settings.CCLIReport;

public class CCLIReportAnalyticsEvents : ICCLIReportAnalyticsEvents
{
	public void Reset()
	{
		EventPublisher.Publish(new CCLIReportResetEvent());
	}

	public void Shown()
	{
		EventPublisher.Publish(new CCLIReportShownEvent());
	}

	public void EditTemplate(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewCopyrightEditorEvent(source));
	}
}
