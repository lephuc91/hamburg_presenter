using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations;

public class MultiTracksSettingsVM : ChildPageSettingsVMBase, IMultiTracksSettingsVM, IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private const string MULTITRACKS_SUPPORT = "https://www.multitracks.com";

	private readonly IMultiTracksConsumer _consumer;

	private readonly IApp _app;

	private readonly ILocalization _localization;

	private string _organizationName = string.Empty;

	private string _userName = string.Empty;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public override string Name => _localization.Get("SETTINGS_MULTITRACKS_PAGE_title");

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public string Username
	{
		get
		{
			return _userName;
		}
		private set
		{
			SetValue("Username", ref _userName, value);
		}
	}

	public string OrganizationName
	{
		get
		{
			return _organizationName;
		}
		private set
		{
			SetValue("OrganizationName", ref _organizationName, value);
		}
	}

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

	public ICommand LoginLogoutCommand => new RelayCommand(delegate
	{
		this.ToggleAuthorization?.Invoke();
	});

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpMultiTracks));
	});

	public ICommand OpenSupportCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(new Uri("https://www.multitracks.com", UriKind.Absolute));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsMultiTracksSearchIcon);

	public event Action? ToggleAuthorization;

	public MultiTracksSettingsVM(IMultiTracksConsumer consumer, IApp app, ILocalization localization, IUiDispatcher uiDispatcher, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		MultiTracksSettingsVM multiTracksSettingsVM = this;
		_consumer = consumer;
		_app = app;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_consumer.SubscriptionAuthorizationUpdated += delegate
		{
			uiDispatcher.InvokeAsync((Func<Task>)async delegate
			{
				await multiTracksSettingsVM.LoadMultiTracksInfoAsync();
			}, default(CancellationToken));
		};
		_consumer.AuthorizationStateUpdated += delegate
		{
			multiTracksSettingsVM.OnPropertyChanged("IsLoggedIn");
			multiTracksSettingsVM.OnPropertyChanged("StatusText");
		};
		LoadMultiTracksInfoAsync().ExecuteAsync();
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_MULTITRACKS_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_MULTITRACKS_USER_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_MULTITRACKS_ORGANIZATION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MULTITRACKS_LOGIN_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MULTITRACKS_LOGOUT_BUTTON_title", this, isComponent: true));
	}

	private async Task LoadMultiTracksInfoAsync()
	{
		TaskCompletionSource<object?> loadInfoCompletionSource = new TaskCompletionSource<object>();
		if (!IsLoggedIn)
		{
			Username = string.Empty;
			OrganizationName = string.Empty;
		}
		else if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(OrganizationName))
		{
			_consumer.GetAccountInfo(delegate(MultiTracksAccountInfo? accountInfo)
			{
				if (accountInfo != null)
				{
					Username = accountInfo.FirstName + " " + accountInfo.LastName;
					OrganizationName = accountInfo.Organization;
				}
				else
				{
					Username = _app.MultiTracksFirstName + " " + _app.MultiTracksLastName;
					OrganizationName = _app.MultiTracksOrganizationName;
				}
				loadInfoCompletionSource.TrySetResult(null);
			});
		}
		else
		{
			loadInfoCompletionSource.TrySetResult(null);
		}
		OnPropertyChanged("IsLoggedIn");
		OnPropertyChanged("StatusText");
		await loadInfoCompletionSource.Task;
	}
}
