using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.Registration.Model.Extensions;

public static class UpdateChannelExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel ToProtoUpdateChannel(this ProPresenter.DO.Registration.Model.UpdateChannel channel)
	{
		return channel switch
		{
			ProPresenter.DO.Registration.Model.UpdateChannel.Beta => Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel.Beta, 
			ProPresenter.DO.Registration.Model.UpdateChannel.Production => Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel.Production, 
			_ => Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel.Production, 
		};
	}
}
