using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations;

public class IntegrationsSettingsVM : LinkedNotifyPropertyChangedBase, IIntegrationsSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IGeneral _general;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; }

	public IPlanningCenterSettingsVM PlanningCenter { get; }

	public IMultiTracksSettingsVM MultiTracks { get; }

	public ISongSelectSettingsVM SongSelect { get; }

	public IResiSettingsVM Resi { get; }

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	public Brush Background => SettingsListItemConstants.Purple;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsIntegrations);

	public bool ShowHoW => _general.ShowHoW;

	public bool IsNavigable => true;

	public bool CanExit => true;

	public IntegrationsSettingsVM(IPlanningCenterSettingsVM planningCenterSettingsVM, IMultiTracksSettingsVM multiTracksSettingsVM, ISongSelectSettingsVM songSelectSettingsVM, IResiSettingsVM resiSettingsVM, ILocalization localization, ISettingsSearchFactory settingsSearchFactory, IGeneral general)
	{
		Name = localization.Get("SETTINGS_INTEGRATIONS_PAGE_title");
		PlanningCenter = planningCenterSettingsVM;
		MultiTracks = multiTracksSettingsVM;
		SongSelect = songSelectSettingsVM;
		Resi = resiSettingsVM;
		_general = general;
		PlanningCenter.SetParent(this);
		MultiTracks.SetParent(this);
		SongSelect.SetParent(this);
		Resi.SetParent(this);
		LinkProperties("ShowHoW", "ShowHoW");
		_general.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		SubPages = new ISettingsSearchPage[4] { PlanningCenter, MultiTracks, SongSelect, Resi };
		Fields = settingsSearchFactory.GetFields("SETTINGS_INTEGRATIONS_PAGE_title", this, isComponent: false, PageField);
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
