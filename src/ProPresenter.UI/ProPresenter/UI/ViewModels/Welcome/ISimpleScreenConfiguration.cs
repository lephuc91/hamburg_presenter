using System.ComponentModel;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface ISimpleScreenConfiguration : INotifyPropertyChanged
{
	HardwareScreenRectangleOptions? MainOutput { get; }

	bool IsConfigured { get; }

	bool IsComplex { get; }
}
