using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record OverlayClosedEvent(OverlayCloseSource Source) : IAnalyticEvent
{
	public static void Publish(OverlayCloseSource source)
	{
		EventPublisher.Publish(new OverlayClosedEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiEditorOverlayClosed = new EditorOverlayClosed
			{
				Source = Source.ToClosedSource()
			};
		});
	}
}
