using Pro.DO.Analytics;
using ProPresenter.DO.Analytics.Events.TrackedEvents.DataDuplicated;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;

public class DataIdDuplicatedEventPublisher : IDataIdDuplicatedEventPublisher
{
	public void Publish(DataType type, int count)
	{
		EventPublisher.Publish(new DataIdDuplicatedEvent(type, count));
	}
}
