using Pro.DO.Storage;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public interface IMediaSettingsVMFactory
{
	IMediaSearchRootVM Create(ISearchRoot searchRoot);
}
