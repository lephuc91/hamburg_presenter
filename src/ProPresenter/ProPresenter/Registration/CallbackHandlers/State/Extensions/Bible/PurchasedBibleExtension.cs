using System.Linq;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.Bible;

public static class PurchasedBibleExtension
{
	public static Purchased ToPurchased(this PurchasedBible bible)
	{
		return new Purchased(bible.Metadata.ToMetadata(), bible.LicensingInfo.ToLicensingInfo());
	}

	private static global::ProPresenter.DO.Registration.State.Bible.LicensingInfo ToLicensingInfo(this Pro.SerializationInterop.RVProtoData.Registration.LicensingInfo licensingInfo)
	{
		return new global::ProPresenter.DO.Registration.State.Bible.LicensingInfo(licensingInfo.IsActiveLocally, licensingInfo.AvailableCopies, licensingInfo.TotalCopies, licensingInfo.OtherActiveCopies.Select(ToActiveCopy).ToArray());
	}

	private static global::ProPresenter.DO.Registration.State.Bible.ActiveCopy ToActiveCopy(this Pro.SerializationInterop.RVProtoData.Registration.ActiveCopy activeCopy)
	{
		return new global::ProPresenter.DO.Registration.State.Bible.ActiveCopy(activeCopy.DisplayName, activeCopy.Hostname);
	}
}
