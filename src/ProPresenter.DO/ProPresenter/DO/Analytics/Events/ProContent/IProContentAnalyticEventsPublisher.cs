namespace ProPresenter.DO.Analytics.Events.ProContent;

public interface IProContentAnalyticEventsPublisher
{
	void ViewMediaBin();

	void Download(bool isRetry);
}
