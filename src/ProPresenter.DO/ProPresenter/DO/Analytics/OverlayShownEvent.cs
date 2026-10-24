using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record OverlayShownEvent(OverlayShowSource Source) : IAnalyticEvent
{
	public static void Publish(OverlayShowSource source)
	{
		EventPublisher.Publish(new OverlayShownEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiEditorOverlayShown = new EditorOverlayShown
			{
				Source = Source.ToShownSource()
			};
		});
	}
}
