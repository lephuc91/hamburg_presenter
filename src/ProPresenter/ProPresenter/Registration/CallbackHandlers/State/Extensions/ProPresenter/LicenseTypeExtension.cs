using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.ProPresenter;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.ProPresenter;

public static class LicenseTypeExtension
{
	public static global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType ToLicenseType(this Pro.SerializationInterop.RVProtoData.Registration.LicenseType type)
	{
		return type switch
		{
			Pro.SerializationInterop.RVProtoData.Registration.LicenseType.Standard => global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType.Standard, 
			Pro.SerializationInterop.RVProtoData.Registration.LicenseType.Campus => global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType.Campus, 
			Pro.SerializationInterop.RVProtoData.Registration.LicenseType.Rental => global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType.Rental, 
			Pro.SerializationInterop.RVProtoData.Registration.LicenseType.Trial => global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType.Trial, 
			_ => global::ProPresenter.DO.Registration.State.ProPresenter.LicenseType.Standard, 
		};
	}
}
