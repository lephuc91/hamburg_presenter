using Google.Protobuf;
using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics;

public abstract record StartupScreenEventBase(ProScreenType ScreenType, bool ScreenColorEnabled) : IAnalyticEvent
{
	public abstract IMessage Serialize();
}
