using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions;

public static class BannerMessageExtension
{
	public static global::ProPresenter.DO.Registration.State.BannerMessage ToBannerMessage(this Pro.SerializationInterop.RVProtoData.Registration.BannerMessage banner)
	{
		return banner switch
		{
			Pro.SerializationInterop.RVProtoData.Registration.BannerMessage.ActivateProPresenter => global::ProPresenter.DO.Registration.State.BannerMessage.ActivateProPresenter, 
			Pro.SerializationInterop.RVProtoData.Registration.BannerMessage.NoBanner => global::ProPresenter.DO.Registration.State.BannerMessage.None, 
			_ => global::ProPresenter.DO.Registration.State.BannerMessage.None, 
		};
	}
}
