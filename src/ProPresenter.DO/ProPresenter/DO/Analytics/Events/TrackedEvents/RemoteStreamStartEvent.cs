using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record RemoteStreamStartEvent(StartStreamResult Result) : IAnalyticEvent
{
	public static void Publish(StartStreamResult result)
	{
		EventPublisher.Publish(new RemoteStreamStartEvent(result));
	}

	private static RemoteStreamStart.Types.StartResult TranslateEnumToProtoEnum(StartStreamResult result)
	{
		return result switch
		{
			StartStreamResult.Success => RemoteStreamStart.Types.StartResult.Success, 
			StartStreamResult.Failure => RemoteStreamStart.Types.StartResult.Failed, 
			StartStreamResult.UserCanceled => RemoteStreamStart.Types.StartResult.Usercanceled, 
			_ => RemoteStreamStart.Types.StartResult.Success, 
		};
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.RemoteStreamStart = new RemoteStreamStart
			{
				Result = TranslateEnumToProtoEnum(Result)
			};
		});
	}
}
