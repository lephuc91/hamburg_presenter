using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Welcome.Events;

public record WelcomeDialogTutorialsViewedEvent : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiWelcomeTutorials = new WelcomeTutorials();
		});
	}
}
