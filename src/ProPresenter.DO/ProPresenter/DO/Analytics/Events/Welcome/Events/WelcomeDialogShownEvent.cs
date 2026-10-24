using System;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Welcome.Events;

public record WelcomeDialogShownEvent(WelcomeToProPresenterLaunchLocation LaunchLocation) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			Pro.SerializationInterop.RVProtoData.Analytics.UI.Welcome welcome = new Pro.SerializationInterop.RVProtoData.Analytics.UI.Welcome();
			Pro.SerializationInterop.RVProtoData.Analytics.UI.Welcome welcome2 = welcome;
			welcome2.Source = LaunchLocation switch
			{
				WelcomeToProPresenterLaunchLocation.FirstLaunch => Pro.SerializationInterop.RVProtoData.Analytics.UI.Welcome.Types.Source.FirstLaunch, 
				WelcomeToProPresenterLaunchLocation.ApplicationMenu => Pro.SerializationInterop.RVProtoData.Analytics.UI.Welcome.Types.Source.ApplicationMenu, 
				_ => throw new NotSupportedException(), 
			};
			e.UiWelcome = welcome;
		});
	}
}
