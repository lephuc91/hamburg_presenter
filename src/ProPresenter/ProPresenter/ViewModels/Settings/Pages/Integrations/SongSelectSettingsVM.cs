using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO.Settings;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations;

public class SongSelectSettingsVM : ChildPageSettingsVMBase, ISongSelectSettingsVM, IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private const string SONGSELECT_SUPPORT = "https://www.ccli.com";

	private readonly ISongSelectConsumer _consumer;

	private readonly IApp _app;

	private readonly IAutoReportDialogPrompt _prompt;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public string Username => string.Empty;

	public string OrganizationName => _consumer.Organization;

	public bool IsLoggedIn => _consumer.IsAuthorized;

	public string StatusText
	{
		get
		{
			if (!IsLoggedIn)
			{
				return _localization.Get("SETTINGS_INTEGRATIONS_LOGGED_OUT_title");
			}
			return _localization.Get("SETTINGS_INTEGRATIONS_LOGGED_IN_title");
		}
	}

	public bool AutoReportSongUsage
	{
		get
		{
			return _app.SongSelectAutoReportSongUsage;
		}
		set
		{
			_app.SongSelectAutoReportSongUsage = value;
		}
	}

	public ICommand LoginLogoutCommand => new RelayCommand(delegate
	{
		this.ToggleAuthorization?.Invoke();
	});

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpSongSelect));
	});

	public ICommand OpenSupportCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(new Uri("https://www.ccli.com", UriKind.Absolute));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsCcli);

	public event Action? ToggleAuthorization;

	public SongSelectSettingsVM(ISongSelectConsumer consumer, IApp app, IAutoReportDialogPrompt prompt, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_consumer = consumer;
		_app = app;
		_prompt = prompt;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = localization.Get("SETTINGS_SONGSELECT_PAGE_title");
		LinkAction("IsAuthorized", OnAuthorizationStateChanged);
		LinkProperties("Organization", "OrganizationName");
		LinkProperties("SongSelectAutoReportSongUsage", "AutoReportSongUsage");
		_consumer.PropertyChanged += base.RaiseLinkedValues;
		_app.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_SONGSELECT_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_SONGSELECT_USER_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_SONGSELECT_AUTO_REPORT_USAGE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SONGSELECT_LOGIN_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SONGSELECT_LOGOUT_BUTTON_title", this, isComponent: true));
	}

	private void OnAuthorizationStateChanged()
	{
		OnPropertyChanged("IsLoggedIn");
		OnPropertyChanged("StatusText");
		if (IsLoggedIn && !_app.SongSelectAutoReportSongUsage)
		{
			AutoReportSongUsage = _prompt.ShowOption();
		}
	}
}
