using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public interface IAlphaKeySettingsVM : INotifyPropertyChanged
{
	AlphaBlendMode Mode { get; set; }

	IReadOnlyCollection<AlphaBlendMode> AvailableModes { get; }

	IHardwareAlphaConfigurationVM HardwareConfiguration { get; }

	IRelayCommand ShowAlphaSettingsHelpCommand { get; }
}
