using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.ForceQuit;

public record ForceQuitEvent(ForceQuitReason Reason) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ForceQuit = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit
			{
				Reason = Reason.ToProto()
			};
		});
	}
}
