using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public interface IBlackmagicHardwareAlphaConfigurationVM : IHardwareAlphaConfigurationVM, INotifyPropertyChanged
{
	BlackmagicAlphaKeyType AlphaKeyType { get; set; }

	double BlendValue { get; set; }

	IEnumerable<BlackmagicAlphaKeyType> SupportedAlphaKeyTypes { get; }
}
