using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BibleCountInstallEvent : BibleCountBase
{
	public BibleCountInstallEvent(int FreeInstalledCount, int PurchasedInstalledCount)
		: base(FreeInstalledCount, PurchasedInstalledCount)
	{
	}

	public static void Publish(int freeInstalledCount, int purchasedInstalledCount)
	{
		EventPublisher.Publish(new BibleCountInstallEvent(freeInstalledCount, purchasedInstalledCount));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleInstall = new BibleInstall
			{
				FreeInstalledCount = base.FreeInstalledCount,
				PurchasedInstalledCount = base.PurchasedInstalledCount
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out int FreeInstalledCount, out int PurchasedInstalledCount)
	{
		FreeInstalledCount = base.FreeInstalledCount;
		PurchasedInstalledCount = base.PurchasedInstalledCount;
	}
}
