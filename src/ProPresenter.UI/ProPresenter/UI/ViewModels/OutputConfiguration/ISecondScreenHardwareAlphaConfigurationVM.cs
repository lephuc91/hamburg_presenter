using System.ComponentModel;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public interface ISecondScreenHardwareAlphaConfigurationVM : IHardwareAlphaConfigurationVM, INotifyPropertyChanged
{
	HardwareScreenRectangleOptions AlphaRectangle { get; }
}
