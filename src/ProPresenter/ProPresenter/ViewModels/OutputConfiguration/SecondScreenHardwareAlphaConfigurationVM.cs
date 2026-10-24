using System.ComponentModel;
using Pro.Common.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class SecondScreenHardwareAlphaConfigurationVM : LinkedNotifyPropertyChangedBase, ISecondScreenHardwareAlphaConfigurationVM, IHardwareAlphaConfigurationVM, INotifyPropertyChanged
{
	public HardwareScreenRectangleOptions AlphaRectangle { get; }

	public SecondScreenHardwareAlphaConfigurationVM(HardwareScreenRectangleOptions alphaRectangleOptions)
	{
		AlphaRectangle = alphaRectangleOptions;
	}
}
