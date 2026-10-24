using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ThemeShowEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new ThemeShowEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiToolbarTheme = new ToolbarThemeShown();
		});
	}
}
