using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class HardwareAlphaConfigurationVMFactory : IHardwareAlphaConfigurationVMFactory
{
	public IHardwareAlphaConfigurationVM? Create(Screen screen)
	{
		if (screen.MainOutput?.OutputDevice is IPhysicalDevice { HardwareSettings: BlackMagicAlphaKeySettings hardwareSettings, SupportsAlphaBlending: not false })
		{
			return new BlackmagicHardwareAlphaConfigurationVM(hardwareSettings);
		}
		if (screen.AlphaOutput != null && screen.MainOutput?.OutputDevice?.SupportsAlphaBlending != true)
		{
			return new SecondScreenHardwareAlphaConfigurationVM(screen.AlphaOutput);
		}
		return null;
	}
}
