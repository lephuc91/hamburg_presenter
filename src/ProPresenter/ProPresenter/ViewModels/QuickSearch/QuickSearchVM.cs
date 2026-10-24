using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class QuickSearchVM : LinkedNotifyPropertyChangedBase, IQuickSearchVM, INotifyPropertyChanged
{
	private readonly List<IQuickSearchPageVM> _pages = new List<IQuickSearchPageVM>();

	private readonly IApp _app;

	private SearchContext? _context;

	private IQuickSearchPageVM? _activePage;

	private string _searchText = string.Empty;

	private readonly IIndexingService _indexingService;

	public IEnumerable<IQuickSearchPageVM> AvailablePages => _pages.Where((IQuickSearchPageVM p) => p.IsEnabled);

	public int? IndexingTotalCount => _indexingService?.TotalIndexCount;

	public int? IndexingProgress => _indexingService?.CurrentIndexedCount;

	public bool DisplayIndexingIndicator
	{
		get
		{
			IIndexingService indexingService = _indexingService;
			if (indexingService != null && indexingService.IsIndexing)
			{
				return ActivePage is LibrarySearchPageVM;
			}
			return false;
		}
	}

	public SearchContext? Context
	{
		get
		{
			return _context;
		}
		set
		{
			SetValue<SearchContext>("Context", ref _context, value, delegate(SearchContext o, SearchContext n)
			{
				ClearSelectedItems();
				AvailablePages.ForEach(delegate(IQuickSearchPageVM p)
				{
					p.Context = n;
				});
				if (ActivePage != null)
				{
					ActivePage = ((ActivePage.RequiresAuthentication && ActivePage.IsAuthenticated) ? ActivePage : AvailablePages.FirstOrDefault());
				}
			});
		}
	}

	public string SearchText
	{
		get
		{
			return _searchText;
		}
		set
		{
			SetValue("SearchText", ref _searchText, value, OnSearchTextChanged);
		}
	}

	public IQuickSearchPageVM? ActivePage
	{
		get
		{
			return _activePage;
		}
		set
		{
			SetValue("ActivePage", ref _activePage, value, OnActivePageChanged);
			OnPropertyChanged("DisplayIndexingIndicator");
		}
	}

	public ICommand<IQuickSearchPageVM> SelectPageCommand => new RelayCommand<IQuickSearchPageVM>(delegate(IQuickSearchPageVM p)
	{
		ActivePage = p;
	}, (IQuickSearchPageVM p) => p != null);

	public event Action? CloseSearch;

	public event Action? SelectAllText;

	public QuickSearchVM(IApp app, IIndexingService indexingService, params IQuickSearchPageVM[] pages)
	{
		_app = app;
		_pages.AddRange(pages);
		LinkAction("IsEnabled", delegate
		{
			OnPropertyChanged("AvailablePages");
			IQuickSearchPageVM? activePage = ActivePage;
			if (activePage == null || !activePage.IsEnabled)
			{
				ActivePage = _pages.GetPrevious<IQuickSearchPageVM>(ActivePage);
			}
		});
		_pages.ForEach(delegate(IQuickSearchPageVM p)
		{
			p.CloseSearch += delegate
			{
				this.CloseSearch?.Invoke();
			};
			p.SelectAllText += delegate
			{
				this.SelectAllText?.Invoke();
			};
			p.PropertyChanged += base.RaiseLinkedValues;
		});
		_activePage = pages.FirstOrDefaultBy((IQuickSearchPageVM p) => p?.SearchType == _app.SelectedSearchPage && p.IsEnabled, (IQuickSearchPageVM p) => p?.IsEnabled ?? false);
		_indexingService = indexingService;
		_indexingService.PropertyChanged += OnIndexingServicePropertyChanged;
	}

	private void OnSearchTextChanged(string oldValue, string newValue)
	{
		ClearSelectedItems();
		ActivePage.SearchText = newValue;
	}

	private void OnActivePageChanged(IQuickSearchPageVM _, IQuickSearchPageVM newValue)
	{
		ClearSelectedItems();
		if (newValue != null)
		{
			newValue.OnActivated();
			if (string.Compare(newValue.SearchText, SearchText, StringComparison.OrdinalIgnoreCase) == 0)
			{
				newValue.RefreshSearch();
			}
			else
			{
				newValue.SearchText = SearchText;
			}
			_app.SelectedSearchPage = newValue.SearchType;
		}
	}

	[MemberNotNull("ActivePage")]
	private void ClearSelectedItems()
	{
		ActivePage.ThrowWhenNull("ActivePage");
		ActivePage.SelectedItems.Clear();
		ActivePage.SelectedItem = null;
	}

	private void OnIndexingServicePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "IsIndexing":
		case "TotalIndexCount":
		case "CurrentIndexedCount":
			OnPropertyChanged("DisplayIndexingIndicator");
			OnPropertyChanged("IndexingTotalCount");
			OnPropertyChanged("IndexingProgress");
			break;
		}
	}
}
