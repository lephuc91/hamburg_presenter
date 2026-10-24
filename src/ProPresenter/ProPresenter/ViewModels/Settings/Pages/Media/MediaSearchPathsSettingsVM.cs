using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using Pro.DO.Storage;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaSearchPathsSettingsVM : ChildPageSettingsVMBase, IMediaSearchPathsSettingsVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly DragDropPairedCollection<ISearchRoot, IMediaSearchRootVM> _searchRoots;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public IDragDropNotifyEnumerableChanged<IMediaSearchRootVM> SearchRoots => _searchRoots;

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpSearchPaths));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsMediaSearch);

	public MediaSearchPathsSettingsVM(IAdvanced advanced, ILocalization localization, IMediaSettingsVMFactory factory, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		Name = localization.Get("SETTINGS_MEDIA_SEARCH_PATHS_PAGE_title");
		_searchRoots = new DragDropPairedCollection<ISearchRoot, IMediaSearchRootVM>(advanced.SearchRoots, factory.Create);
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_MEDIA_SEARCH_PATHS_PAGE_title", this, isComponent: false, PageField);
	}
}
