using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ClearGroupShownEvent(ClearGroupShownSource Source) : IAnalyticEvent
{
	public static void Publish(ClearGroupShownSource source)
	{
		EventPublisher.Publish(new ClearGroupShownEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiClearGroups = new Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups
			{
				Source = Source.ToProto()
			};
		});
	}
}
