using Google.Protobuf;
using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics;

public abstract record BibleCountBase(int FreeInstalledCount, int PurchasedInstalledCount) : IAnalyticEvent
{
	public abstract IMessage Serialize();
}
