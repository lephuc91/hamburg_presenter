using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics;

public record BootstrappingCompleteEvent(string? Error) : IAnalyticEvent
{
	public static void Publish(string? error)
	{
		EventPublisher.Publish(new BootstrappingCompleteEvent(error));
	}

	public IMessage Serialize()
	{
		BootstrappingComplete messageObject = new BootstrappingComplete();
		if (string.IsNullOrEmpty(Error))
		{
			messageObject.Success = new BootstrappingComplete.Types.Success();
		}
		else
		{
			messageObject.Failure = new BootstrappingComplete.Types.Failure
			{
				Error = Error
			};
		}
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementBootstrappingComplete = messageObject;
		});
	}
}
