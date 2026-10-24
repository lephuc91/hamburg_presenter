using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class MultiTracksSearchPageVM : SearchPageVMBase
{
	private readonly IMultiTracksSearchService _service;

	private readonly IInputActions _inputActions;

	private readonly MultiTracksPreviewVM _previewVM;

	private readonly SearchCommandVM _open;

	private readonly SearchCommandVM _linkToItem;

	private readonly IGeneral _general;

	private readonly DispatcherTimer _searchTimer = new DispatcherTimer
	{
		Interval = TimeSlice.FromSeconds(0.5)
	};

	private readonly ObservableCollection<MultiTracksSearchResult> _searchResults = new ObservableCollection<MultiTracksSearchResult>();

	public override QuickSearchType SearchType => QuickSearchType.MultiTracks;

	public override IQuickSearchPreviewVM PreviewVM => _previewVM;

	public override bool IsEnabled => _general.ShowHoW;

	public override bool CanDrag => true;

	public override bool CanMultiSelect => false;

	public override bool RequiresAuthentication => true;

	public override bool IsAuthenticated => _service.IsAuthorized;

	public override string PlaceholderSearchText => LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_MULTITRACKS_placeholder");

	public override string FooterText
	{
		get
		{
			SearchContext? context = base.Context;
			if (context != null && context.Mode != 0)
			{
				return LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_FOOTER_IMPORT_AND_LINK_label", new object[1] { "[" + _inputActions.CommonInputActions.Submit.KeyboardGesture?.GestureText + "]" });
			}
			return LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_FOOTER_IMPORT_label", new object[1] { "[" + _inputActions.CommonInputActions.Submit.KeyboardGesture?.GestureText + "]" });
		}
	}

	public ICommand LinkToItemCommand => new RelayCommand(OnLinkToItemCommand, () => base.SelectedItem != null);

	public override ICollectionView Items { get; }

	public MultiTracksSearchPageVM(IMultiTracksSearchService service, ICommonInputActionGroup commonInputActionGroup, IInputActions inputActions, IGeneral general)
		: base(commonInputActionGroup.Submit.BindCommand)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		_service = service;
		_general = general;
		_inputActions = inputActions;
		_service.RefreshSearchResults += RefreshSearch;
		_open = new SearchCommandVM(LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_MULTITRACKS_IMPORT_title"), base.SubmitCommand, base.OpenItemCommand);
		_linkToItem = new SearchCommandVM(LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_SONG_SELECT_IMPORT_AND_LINK_title"), base.SubmitCommand, LinkToItemCommand);
		_previewVM = new MultiTracksPreviewVM(_open, _linkToItem);
		Items = CollectionViewSource.GetDefaultView(_searchResults);
		_general.PropertyChanged += base.RaiseLinkedValues;
		_searchTimer.Tick += delegate
		{
			OnExecuteSearch();
		};
		ContextUpdated();
	}

	public override void OnActivated()
	{
		_service.TryLogin();
	}

	public override void RefreshSearch()
	{
		OnSearchTextChanged(null, base.SearchText);
	}

	protected sealed override void ContextUpdated()
	{
		SearchContext.SearchMode searchMode = base.Context?.Mode ?? SearchContext.SearchMode.Standard;
		_open.IsVisible = searchMode == SearchContext.SearchMode.Standard;
		_linkToItem.IsVisible = searchMode == SearchContext.SearchMode.Linking;
	}

	protected override void OnSearchTextChanged(string? _, string searchText)
	{
		_searchResults.Clear();
		_searchTimer.Stop();
		_searchTimer.Start();
	}

	private void OnExecuteSearch()
	{
		_searchTimer.Stop();
		if (string.IsNullOrEmpty(base.SearchText))
		{
			return;
		}
		_service.Search(base.SearchText, delegate(MultiTracksSearchResults result)
		{
			if (result != null)
			{
				_searchResults.AddRange(result.Items);
				PublishExecutedEvent();
			}
		});
	}

	protected override void OnSelectedItemChanged(object oldItem, object newItem)
	{
		_previewVM.ActiveSearchResult = (MultiTracksSearchResult)newItem;
	}

	protected override void OnItemOpened()
	{
		if (base.SelectedItem is MultiTracksSearchResult searchResult)
		{
			_service.Import(searchResult);
		}
		OnCloseSearch();
	}

	private void OnLinkToItemCommand()
	{
		(base.Context?.Target).ThrowWhenNull("Context?.Target");
		base.SelectedItem.ThrowWhenNull("SelectedItem");
		_service.ImportAndLinkToItem(base.Context.Target, (MultiTracksSearchResult)base.SelectedItem);
		OnCloseSearch();
	}
}
