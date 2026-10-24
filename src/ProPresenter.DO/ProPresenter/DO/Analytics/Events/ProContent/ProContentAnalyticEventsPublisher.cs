using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.ProContent;

public class ProContentAnalyticEventsPublisher : IProContentAnalyticEventsPublisher
{
	public void Download(bool isRetry)
	{
		if (isRetry)
		{
			EventPublisher.Publish(new ProContentDownloadRetryEvent());
		}
		else
		{
			EventPublisher.Publish(new ProContentDownloadEvent());
		}
	}

	public void ViewMediaBin()
	{
		EventPublisher.Publish(new ProContentViewMediaBinEvent());
	}
}
