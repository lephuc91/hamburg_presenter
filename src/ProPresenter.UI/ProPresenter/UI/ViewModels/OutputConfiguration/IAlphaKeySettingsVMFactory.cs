using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public interface IAlphaKeySettingsVMFactory
{
	IAlphaKeySettingsVM Create(Screen screen);
}
