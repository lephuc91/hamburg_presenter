using Pro.DO.Storage;
using Pro.Localization.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaSettingsVMFactory : IMediaSettingsVMFactory
{
	private readonly ILocalization _localization;

	public MediaSettingsVMFactory(ILocalization localization)
	{
		_localization = localization;
	}

	public IMediaSearchRootVM Create(ISearchRoot searchRoot)
	{
		return new MediaSearchRootVM(searchRoot, _localization);
	}
}
