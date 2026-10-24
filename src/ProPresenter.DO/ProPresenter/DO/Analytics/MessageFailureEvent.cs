using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics;

public record MessageFailureEvent(string Error) : IAnalyticEvent
{
	public static void Publish(string error)
	{
		EventPublisher.Publish(new MessageFailureEvent(error));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementMessageFailure = new MessageFailure
			{
				Error = Error
			};
		});
	}
}
