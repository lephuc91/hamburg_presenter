using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics;

public record ConnectionStateChangedEvent(bool IsConnected) : IAnalyticEvent
{
	public static void Publish(bool isConnected)
	{
		EventPublisher.Publish(new ConnectionStateChangedEvent(isConnected));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementConnectionChanged = new ConnectionChanged
			{
				State = ((!IsConnected) ? ConnectionChanged.Types.State.Disconnected : ConnectionChanged.Types.State.Connected)
			};
		});
	}
}
