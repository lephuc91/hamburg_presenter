using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations;

public class PlanningCenterSettingsVM : ChildPageSettingsVMBase, IPlanningCenterSettingsVM, IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private const string PLANNINGCENTER_SUPPORT = "https://www.planningcenter.com/services";

	private readonly IPCOConsumer _pcoConsumer;

	private readonly IProPresenterResourceService _resources;

	private readonly IStoredPcoOptions _pcoOptions;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public string Username => _pcoConsumer.Username;

	public string OrganizationName => _pcoOptions.OrganizationName;

	public bool IsLoggedIn => _pcoConsumer.IsAuthorized;

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

	public bool AutoPlanUpdate
	{
		get
		{
			return _pcoOptions.AutoPlanUpdate;
		}
		set
		{
			_pcoOptions.AutoPlanUpdate = value;
		}
	}

	public bool MatchSongs
	{
		get
		{
			return _pcoOptions.MatchSongs;
		}
		set
		{
			_pcoOptions.MatchSongs = value;
		}
	}

	public bool ShowHistoricalPlans
	{
		get
		{
			return _pcoOptions.ShowHistoricalPlans;
		}
		set
		{
			_pcoOptions.ShowHistoricalPlans = value;
		}
	}

	public bool ArrangementFromSequences
	{
		get
		{
			return _pcoOptions.ArrangementFromSequences;
		}
		set
		{
			_pcoOptions.ArrangementFromSequences = value;
		}
	}

	public bool AutoUpload
	{
		get
		{
			return _pcoOptions.AutoUpload;
		}
		set
		{
			_pcoOptions.AutoUpload = value;
		}
	}

	public bool AutoDownload
	{
		get
		{
			return _pcoOptions.AutoDownload;
		}
		set
		{
			_pcoOptions.AutoDownload = value;
		}
	}

	public string TargetLibrary
	{
		get
		{
			return _pcoOptions.TargetLibrary;
		}
		set
		{
			_pcoOptions.TargetLibrary = value;
		}
	}

	public IEnumerable<IIdentifiable> LibraryCollection => _resources.LibraryCollection.OfType<IIdentifiable>();

	public ICommand LoginLogoutCommand => new RelayCommand(delegate
	{
		this.ToggleAuthorization?.Invoke();
	});

	public ICommand<IIdentifiable> SelectLibraryCommand => new RelayCommand<IIdentifiable>(delegate(IIdentifiable l)
	{
		_pcoOptions.TargetLibrary = l.Name;
	});

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpPlanningCenter));
	});

	public ICommand OpenSupportCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(new Uri("https://www.planningcenter.com/services", UriKind.Absolute));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsPlanningCenterSearchIcon);

	public event Action? ToggleAuthorization;

	public PlanningCenterSettingsVM(IPCOConsumer pcoConsumer, IProPresenterResourceService resources, IStoredPcoOptions pcoOptions, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		Name = localization.Get("SETTINGS_PLANNING_CENTER_PAGE_title");
		_pcoConsumer = pcoConsumer;
		_resources = resources;
		_pcoOptions = pcoOptions;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		LinkProperties("Username", Username);
		LinkProperties("AuthorizationState", new string[2] { "IsLoggedIn", "StatusText" });
		LinkProperties("OrganizationName", "OrganizationName");
		LinkProperties("AutoPlanUpdate", "AutoPlanUpdate");
		LinkProperties("MatchSongs", "MatchSongs");
		LinkProperties("ShowHistoricalPlans", "ShowHistoricalPlans");
		LinkProperties("ArrangementFromSequences", "ArrangementFromSequences");
		LinkProperties("AutoUpload", "AutoUpload");
		LinkProperties("AutoDownload", "AutoDownload");
		LinkProperties("TargetLibrary", "TargetLibrary");
		_pcoConsumer.PropertyChanged += base.RaiseLinkedValues;
		_pcoOptions.PropertyChanged += base.RaiseLinkedValues;
		_resources.LibraryCollection.CollectionChanged += delegate
		{
			OnPropertyChanged("LibraryCollection");
		};
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_USER_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_ORGANIZATION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_AUTO_CHECK_PLAN_UPDATES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_MATCH_PRESENTATIONS_IN_LIBRARY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_SHOW_HISTORICAL_SERVICE_PLANS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_MAKE_ARRANGEMENTS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_AUTO_UPLOAD_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_AUTO_DOWNLOAD_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_DOWNLOAD_LIBRARY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_LOGIN_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PLANNING_CENTER_LOGOUT_BUTTON_title", this, isComponent: true));
	}
}
