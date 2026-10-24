using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.API;

namespace ProPresenter.DO.Analytics;

public record MessageReceived : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new MessageReceived());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ApiMessageReceived = new Pro.SerializationInterop.RVProtoData.Analytics.API.MessageReceived();
		});
	}
}
