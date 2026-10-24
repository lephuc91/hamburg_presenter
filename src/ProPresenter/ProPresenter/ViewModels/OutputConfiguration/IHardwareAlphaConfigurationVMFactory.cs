using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public interface IHardwareAlphaConfigurationVMFactory
{
	IHardwareAlphaConfigurationVM? Create(Screen screen);
}
