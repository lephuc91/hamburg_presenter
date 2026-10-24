using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class LibrarySearchPageVM : SearchPageVMBase, ILibrarySearchController, INotifyPropertyChanged
{
	private readonly ILibrarySearchService _service;

	private readonly ILocalization _localization;

	private readonly IProPresenterGroup _proPresenterGroup;

	private readonly ICommonInputActionGroup _commonInputActionGroup;

	private readonly LibraryPreviewVM _previewVM;

	private readonly SearchCommandVM _addToPlaylist;

	private readonly SearchCommandVM _linkToItem;

	private readonly SearchCommandVM _open;

	public override QuickSearchType SearchType => QuickSearchType.Library;

	public override IQuickSearchPreviewVM PreviewVM => _previewVM;

	public override string PlaceholderSearchText => _localization.Get("PRESENTATION_QUICK_SEARCH_LIBRARY_placeholder");

	public override string FooterText
	{
		get
		{
			SearchContext? context = base.Context;
			if (context != null && context.Mode != 0)
			{
				return _localization.Get("PRESENTATION_QUICK_SEARCH_FOOTER_LINK_label", new object[1] { "[" + _commonInputActionGroup.Submit.KeyboardGesture?.GestureText + "]" });
			}
			global::_003C_003Ey__InlineArray2<string> buffer = default(global::_003C_003Ey__InlineArray2<string>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 0) = _localization.Get("PRESENTATION_QUICK_SEARCH_FOOTER_ADD_TO_PLAYLIST_label", new object[1] { "[" + _proPresenterGroup.AddSelectedCuesToPlaylist.KeyboardGesture?.GestureText + "]" });
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 1) = _localization.Get("PRESENTATION_QUICK_SEARCH_FOOTER_OPEN_label", new object[1] { "[" + _commonInputActionGroup.Submit.KeyboardGesture?.GestureText + "]" });
			return string.Join("\t", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<string>, string>(in buffer, 2));
		}
	}

	public ICommand AddToPlaylistCommand => new RelayCommand(OnAddSelectedCuesToPlaylistCommand, ((IEnumerable<object>)base.SelectedItems).Any<object>);

	public ICommand LinkToItemCommand => new RelayCommand(OnLinkToItemCommand, ((IEnumerable<object>)base.SelectedItems).Any<object>);

	public override ICollectionView Items { get; }

	public LibrarySearchPageVM(ILibrarySearchService service, IMultiTracksSearchService multiTracksSearchService, IApp app, ILocalization localization, IProPresenterGroup proPresenterGroup, ICommonInputActionGroup commonInputActionGroup)
		: base(commonInputActionGroup.Submit.BindCommand)
	{
		_addToPlaylist = new SearchCommandVM(localization.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_LIBRARY_ADD_TO_PLAYLIST_BUTTON_title"), proPresenterGroup.AddSelectedCuesToPlaylist.BindCommand, AddToPlaylistCommand);
		_open = new SearchCommandVM(localization.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_LIBRARY_OPEN_BUTTON_title"), base.SubmitCommand, base.OpenItemCommand);
		_linkToItem = new SearchCommandVM(localization.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_LIBRARY_LINK_BUTTON_title"), base.SubmitCommand, LinkToItemCommand);
		_previewVM = new LibraryPreviewVM(multiTracksSearchService, app, localization, _addToPlaylist, _linkToItem, _open);
		_service = service;
		_localization = localization;
		_proPresenterGroup = proPresenterGroup;
		_commonInputActionGroup = commonInputActionGroup;
		Items = CollectionViewSource.GetDefaultView(_service.Items);
		LinkAction("Items", (Action)Items.Refresh, (Type?)null);
		LinkAction("PlaylistAvailable", ContextUpdated);
		_service.PropertyChanged += base.RaiseLinkedValues;
		ContextUpdated();
	}

	public override void RefreshSearch()
	{
		OnSearchTextChanged(null, base.SearchText);
	}

	protected sealed override void ContextUpdated()
	{
		SearchContext.SearchMode searchMode = base.Context?.Mode ?? SearchContext.SearchMode.Standard;
		_addToPlaylist.IsVisible = searchMode == SearchContext.SearchMode.Standard && _service.PlaylistAvailable;
		_open.IsVisible = searchMode == SearchContext.SearchMode.Standard;
		_linkToItem.IsVisible = searchMode == SearchContext.SearchMode.Linking;
	}

	protected override void OnSearchTextChanged(string? _, string searchText)
	{
		_service.Search(searchText, onSearchComplete);
		void onSearchComplete()
		{
			RefreshViewSource();
			PublishExecutedEvent();
		}
	}

	protected override void OnSelectedItemChanged(object oldItem, object newItem)
	{
		_previewVM.SelectedPresentation = ((DocumentCue)base.SelectedItem)?.DocumentAction.Presentation;
	}

	protected override void OnItemOpened()
	{
		if (base.SelectedItem is DocumentCue documentCue)
		{
			_service.Open(documentCue);
		}
		OnCloseSearch();
	}

	private void OnAddSelectedCuesToPlaylistCommand()
	{
		PublishImportEvent(base.SelectedItems.Count, QuickSearchStyle.AddToPlaylist);
		_service.AddToPlaylist(from i in base.SelectedItems.OrderBy(((IEnumerable)Items).IndexOf)
			select (DocumentCue)((ProPresenterCue)i).Clone());
		OnSelectAllText();
	}

	private void OnLinkToItemCommand()
	{
		_service.LinkToItem(base.Context?.Target, base.SelectedItems.OfType<DocumentCue>().First());
		OnCloseSearch();
		PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, PlaceholderLinkSource.QuickSearch);
	}

	private void RefreshViewSource()
	{
		((Collection<SortDescription>)(object)Items.SortDescriptions).Clear();
		if (!base.IsSearching)
		{
			addSortDescriptions(new string[2] { "Name", "LibraryName" });
		}
		void addSortDescriptions(string[] properties)
		{
			properties.ForEach(delegate(string p)
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				((Collection<SortDescription>)(object)Items.SortDescriptions).Add(new SortDescription(p, ListSortDirection.Ascending));
			});
		}
	}
}
