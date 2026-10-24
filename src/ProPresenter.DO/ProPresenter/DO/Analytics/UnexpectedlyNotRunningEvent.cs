using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics;

public record UnexpectedlyNotRunningEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new UnexpectedlyNotRunningEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementUnexpectedlyNotRunning = new UnexpectedlyNotRunning();
		});
	}
}
