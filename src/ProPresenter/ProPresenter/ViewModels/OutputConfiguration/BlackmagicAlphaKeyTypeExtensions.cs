using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public static class BlackmagicAlphaKeyTypeExtensions
{
	public static ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType ToViewModelType(this ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType type)
	{
		if (type == ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType.External)
		{
			return ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType.External;
		}
		return ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType.Internal;
	}

	public static ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType ToDataObjectType(this ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType type)
	{
		if (type == ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType.External)
		{
			return ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType.External;
		}
		return ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType.Internal;
	}
}
