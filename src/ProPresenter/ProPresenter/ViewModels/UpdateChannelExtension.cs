using ProPresenter.DO.Registration.Model;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public static class UpdateChannelExtension
{
	public static ProPresenter.DO.Registration.Model.UpdateChannel ToDoUpdateChannel(this ProPresenter.UI.ViewModels.UpdateChannel channel)
	{
		if (channel == ProPresenter.UI.ViewModels.UpdateChannel.Beta)
		{
			return ProPresenter.DO.Registration.Model.UpdateChannel.Beta;
		}
		return ProPresenter.DO.Registration.Model.UpdateChannel.Production;
	}

	public static ProPresenter.UI.ViewModels.UpdateChannel ToVmUpdateChannel(this ProPresenter.DO.Registration.Model.UpdateChannel channel)
	{
		if (channel == ProPresenter.DO.Registration.Model.UpdateChannel.Beta)
		{
			return ProPresenter.UI.ViewModels.UpdateChannel.Beta;
		}
		return ProPresenter.UI.ViewModels.UpdateChannel.Production;
	}
}
