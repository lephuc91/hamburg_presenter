using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.HTTP;
using Pro.Common.OAuth;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Resi;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Resi;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations;

public class ResiSettingsVM : ChildPageSettingsVMBase, IResiSettingsVM, IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IResiController _controller;

	private readonly IResiAuthorizationInteractor _resiLogin;

	private readonly IResiPrompt _prompt;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly AsyncRelayCommand _checkUpdateCommand;

	private readonly AsyncRelayCommand _loginCommand;

	private readonly AsyncRelayCommand _logoutCommand;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public string Username => _controller.UserName;

	public string OrganizationName => string.Empty;

	public bool IsLoggedIn => _controller.AuthorizationState == CredentialState.Authorized;

	public string StatusText
	{
		get
		{
			if (!IsLoggedIn)
			{
				return _localization.Get("SETTINGS_RESI_ACCOUNT_UNREGISTERED_title");
			}
			return _localization.Get("SETTINGS_RESI_ACCOUNT_REGISTERED_title");
		}
	}

	public string AccountStatus => _localization.Get(_controller.AccountStatus);

	public string SupportLinkMask
	{
		get
		{
			if (!IsLoggedIn)
			{
				return "resi.io";
			}
			return "resi.io/contact";
		}
	}

	public string EncoderName
	{
		get
		{
			if (!(_controller.PluginVersion != null))
			{
				return string.Empty;
			}
			return _controller.EncoderName ?? _localization.Get("SETTINGS_RESI_ENCODER_VERSION_INFO_NOT_AVAILABLE");
		}
	}

	public UpdateStatusInternal UpdateStatus => ToUpdateStatusInternal(_controller.UpdateStatus);

	public string PluginVersion
	{
		get
		{
			if (UpdateStatus == UpdateStatusInternal.Starting)
			{
				return string.Empty;
			}
			return _controller.PluginVersion?.ToString() ?? _localization.Get("SETTINGS_RESI_ENCODER_PLUGIN_NOT_FOUND");
		}
	}

	public string Schedule => _localization.Get("SETTINGS_RESI_ENCODER_SCHEDULE_label", new object[1] { _controller.Schedule });

	public string DownloadButtonLabel => _localization.Get(_controller.PluginInstalled ? "SETTINGS_RESI_ENCODER_INSTALL_UPDATE_BUTTON_title" : "SETTINGS_RESI_ENCODER_INSTALL_PLUGIN_BUTTON_title");

	public bool ShowDownload
	{
		get
		{
			if (_controller.UpdateAvailable || _controller.PluginVersion == null)
			{
				return UpdateStatus == UpdateStatusInternal.None;
			}
			return false;
		}
	}

	public bool ShowCheckUpdate
	{
		get
		{
			if (_controller.PluginVersion != null && !_controller.UpdateAvailable)
			{
				return UpdateStatus == UpdateStatusInternal.None;
			}
			return false;
		}
	}

	public double DownloadProgress => _controller.DownloadProgress;

	public ICommand LoginLogoutCommand => new RelayCommand(delegate
	{
		this.ToggleAuthorization?.Invoke();
	});

	public ICommand MoreInfoCommand => new RelayCommand(MoreInfoCommandExecuted, _controller.CanShowMoreInfo);

	public ICommand ManageCommand => new RelayCommand(ManageCommandExecuted);

	public ICommand DownloadCommand => new RelayCommand(DownloadCommandExecuted);

	public ICommand CancelDownloadCommand => new RelayCommand(CancelDownloadCommandExecuted);

	public ICommand SupportLinkCommand => new RelayCommand(SupportLinkCommandExecuted);

	public ICommand CheckUpdateCommand => _checkUpdateCommand;

	public ICommand LoginCommand => _loginCommand;

	public ICommand LogoutCommand => _logoutCommand;

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpResi));
	});

	public ICommand OpenSupportCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(new Uri("https://www." + SupportLinkMask, UriKind.Absolute));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsResiSearchIcon);

	public event Action? ToggleAuthorization;

	public ResiSettingsVM(IResiController controller, IResiAuthorizationInteractor resiLogin, IResiPrompt prompt, IResiUpdateVM resiUpdateVM, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		ResiSettingsVM resiSettingsVM = this;
		_controller = controller;
		_resiLogin = resiLogin;
		_prompt = prompt;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = localization.Get("SETTINGS_RESI_PAGE_title");
		_checkUpdateCommand = new AsyncRelayCommand(() => resiUpdateVM.CheckForUpdateAsync(manualCheck: true), () => resiSettingsVM._controller.CanCheckForUpdate);
		_loginCommand = new AsyncRelayCommand(_resiLogin.ExecuteLoginAsync, () => resiSettingsVM._resiLogin.CanExecute);
		_logoutCommand = new AsyncRelayCommand(LogoutCommandExecutedAsync, () => resiSettingsVM._resiLogin.CanExecute);
		LinkProperties("AuthorizationState", new string[3] { "IsLoggedIn", "StatusText", "SupportLinkMask" });
		LinkProperties("UserName", "Username");
		LinkProperties("AccountStatus", "AccountStatus");
		LinkProperties("EncoderName", "EncoderName");
		LinkProperties("PluginVersion", new string[2] { "PluginVersion", "DownloadButtonLabel" });
		LinkProperties("Schedule", "Schedule");
		LinkProperties("UpdateAvailable", new string[2] { "ShowDownload", "ShowCheckUpdate" });
		LinkProperties("UpdateStatus", new string[4] { "UpdateStatus", "ShowDownload", "ShowCheckUpdate", "PluginVersion" });
		LinkProperties("DownloadProgress", "DownloadProgress");
		LinkAction("CurrentStatus", delegate
		{
			resiSettingsVM._checkUpdateCommand.NotifyCanExecuteChanged();
		});
		LinkAction("CanExecute", delegate
		{
			resiSettingsVM._loginCommand.NotifyCanExecuteChanged();
			resiSettingsVM._logoutCommand.NotifyCanExecuteChanged();
		});
		_controller.PropertyChanged += base.RaiseLinkedValues;
		_resiLogin.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_RESI_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_SECTION_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_ORGANIZATION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_STATUS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_MANAGE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_REGISTER_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_UNREGISTER_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ENCODER_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ENCODER_NAME_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ENCODER_VERSION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ENCODER_CHECK_UPDATE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ENCODER_CAPTURE_SETTINGS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_RESI_ACCOUNT_MORE_INFO_BUTTON_title", this, isComponent: true));
	}

	private async Task LogoutCommandExecutedAsync()
	{
		if (_prompt.ConfirmLogout())
		{
			await _resiLogin.ExecuteLogoutAsync();
		}
	}

	private void MoreInfoCommandExecuted()
	{
		_controller.ShowMoreInfo();
	}

	private void ManageCommandExecuted()
	{
		_controller.Manage();
	}

	private void DownloadCommandExecuted()
	{
		_controller.Download();
	}

	private void CancelDownloadCommandExecuted()
	{
		_controller.CancelDownload();
	}

	private void SupportLinkCommandExecuted()
	{
		_controller.NavigateSupportLink();
	}

	private UpdateStatusInternal ToUpdateStatusInternal(UpdateStatus status)
	{
		return status switch
		{
			ProPresenter.DO.Resi.UpdateStatus.None => UpdateStatusInternal.None, 
			ProPresenter.DO.Resi.UpdateStatus.Downloading => UpdateStatusInternal.Downloading, 
			ProPresenter.DO.Resi.UpdateStatus.Installing => UpdateStatusInternal.Installing, 
			ProPresenter.DO.Resi.UpdateStatus.Starting => UpdateStatusInternal.Starting, 
			_ => UpdateStatusInternal.None, 
		};
	}
}
