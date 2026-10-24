using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Settings;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class SongSelectSearchPageVM : SearchPageVMBase
{
	private readonly ISongSelectSearchService _service;

	private readonly IInputActions _inputActions;

	private readonly IGeneral _general;

	private readonly SongSelectPreviewVM _previewVM;

	private readonly SearchCommandVM _open;

	private readonly SearchCommandVM _linkToItem;

	public override QuickSearchType SearchType => QuickSearchType.SongSelect;

	public override IQuickSearchPreviewVM PreviewVM => _previewVM;

	public override bool IsEnabled => _general.ShowHoW;

	public override bool RequiresAuthentication => true;

	public override bool IsAuthenticated => _service.IsAuthorized;

	public override bool CanDrag => true;

	public override bool CanMultiSelect => false;

	public override string PlaceholderSearchText => LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_SONGSELECT_placeholder");

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

	public SongSelectSearchPageVM(ISongSelectSearchService service, ICommonInputActionGroup commonInputActionGroup, IInputActions inputActions, IGeneral general)
		: base(commonInputActionGroup.Submit.BindCommand)
	{
		_open = new SearchCommandVM(LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_SONG_SELECT_IMPORT_title"), base.SubmitCommand, base.OpenItemCommand);
		_linkToItem = new SearchCommandVM(LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_PREVIEW_SONG_SELECT_IMPORT_AND_LINK_title"), base.SubmitCommand, LinkToItemCommand);
		_previewVM = new SongSelectPreviewVM(_open, _linkToItem);
		_service = service;
		_inputActions = inputActions;
		_general = general;
		Items = CollectionViewSource.GetDefaultView(_service.Items);
		LinkAction("Items", (Action)Items.Refresh, (Type?)null);
		LinkProperties("ShowHoW", "IsEnabled");
		_service.PropertyChanged += base.RaiseLinkedValues;
		general.PropertyChanged += base.RaiseLinkedValues;
		ContextUpdated();
	}

	public override void OnActivated()
	{
		_service.CheckAvailability();
	}

	public override void RefreshSearch()
	{
		OnSearchTextChanged(null, base.SearchText);
	}

	protected override void ContextUpdated()
	{
		SearchContext.SearchMode searchMode = base.Context?.Mode ?? SearchContext.SearchMode.Standard;
		_open.IsVisible = searchMode == SearchContext.SearchMode.Standard;
		_linkToItem.IsVisible = searchMode == SearchContext.SearchMode.Linking;
	}

	protected override void OnSelectedItemChanged(object oldItem, object newItem)
	{
		_previewVM.SelectedItemToPreview = (ISongSelectSearchResult)newItem;
	}

	protected override void OnItemOpened()
	{
		if (base.SelectedItem is ISongSelectSearchResult selectedItem)
		{
			_service.Import(selectedItem);
		}
		OnCloseSearch();
	}

	private void OnLinkToItemCommand()
	{
		(base.Context?.Target).ThrowWhenNull("Context?.Target");
		base.SelectedItem.ThrowWhenNull("SelectedItem");
		_service.ImportAndLinkToItem(base.Context.Target, (ISongSelectSearchResult)base.SelectedItem);
		OnCloseSearch();
	}

	protected override void OnSearchTextChanged(string? _, string searchText)
	{
		_service.Search(searchText, base.PublishExecutedEvent);
	}
}
