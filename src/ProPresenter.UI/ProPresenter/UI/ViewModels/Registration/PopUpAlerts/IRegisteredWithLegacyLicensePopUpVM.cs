using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public interface IRegisteredWithLegacyLicensePopUpVM
{
	IRelayCommand HelpCommand { get; }

	IRelayCommand MigrateCommand { get; }
}
