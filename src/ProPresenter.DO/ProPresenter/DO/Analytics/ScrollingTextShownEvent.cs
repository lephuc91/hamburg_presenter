using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ScrollingTextShownEvent(bool Enabled) : IAnalyticEvent
{
	public static void Publish(bool enabled)
	{
		EventPublisher.Publish(new ScrollingTextShownEvent(enabled));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTextinspectorScrollingText = new TextInspectorScrollingText
			{
				Enabled = Enabled
			};
		});
	}
}
