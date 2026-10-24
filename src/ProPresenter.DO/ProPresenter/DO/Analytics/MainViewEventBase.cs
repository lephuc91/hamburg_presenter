using Google.Protobuf;
using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics;

public abstract record MainViewEventBase(MainViewSource Source) : IAnalyticEvent
{
	public abstract IMessage Serialize();
}
