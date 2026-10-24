using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.ProPresenter;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.ProPresenter;

public static class SeatInfoExtension
{
	public static SeatInformation ToSeatInfo(this LicenseInfo licenseInfo, SeatInformation? previousSeatInfo)
	{
		return new SeatInformation(licenseInfo.RegistrationInfo.SeatType != SeatType.Inactive, licenseInfo.TotalSeats?.Basic ?? previousSeatInfo?.TotalSeats ?? (-1), licenseInfo.AvailableSeats?.Basic ?? previousSeatInfo?.AvailableSeats ?? (-1));
	}
}
