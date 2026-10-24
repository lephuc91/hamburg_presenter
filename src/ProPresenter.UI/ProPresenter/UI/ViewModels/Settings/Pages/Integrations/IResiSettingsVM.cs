using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public interface IResiSettingsVM : IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	string AccountStatus { get; }

	string PluginVersion { get; }

	string Schedule { get; }

	bool ShowDownload { get; }

	bool ShowCheckUpdate { get; }

	UpdateStatusInternal UpdateStatus { get; }

	double DownloadProgress { get; }

	string DownloadButtonLabel { get; }

	string SupportLinkMask { get; }

	string EncoderName { get; }

	ICommand MoreInfoCommand { get; }

	ICommand ManageCommand { get; }

	ICommand DownloadCommand { get; }

	ICommand CancelDownloadCommand { get; }

	ICommand SupportLinkCommand { get; }

	ICommand CheckUpdateCommand { get; }

	ICommand LoginCommand { get; }

	ICommand LogoutCommand { get; }

	ICommand HelpCommand { get; }
}
