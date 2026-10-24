namespace ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;

public interface IDataIdDuplicatedEventPublisher
{
	void Publish(DataType type, int count);
}
