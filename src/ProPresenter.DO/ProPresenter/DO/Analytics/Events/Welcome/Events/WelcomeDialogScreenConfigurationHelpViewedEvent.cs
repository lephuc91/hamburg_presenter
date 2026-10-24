using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Welcome.Events;

public record WelcomeDialogScreenConfigurationHelpViewedEvent : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiWelcomeScreenConfigurationHelp = new WelcomeScreenConfigurationHelp();
		});
	}
}
