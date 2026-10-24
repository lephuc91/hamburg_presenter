using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics.Events.MediaManagement;

public class UnresponsiveEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new UnresponsiveEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementNotResponding = new NotResponding();
		});
	}
}
