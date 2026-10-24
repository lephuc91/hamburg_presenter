using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public abstract class SearchPageVMBase : LinkedNotifyPropertyChangedBase, IQuickSearchPageVM, INotifyPropertyChanged
{
	private SearchContext? _context;

	private string _searchText = string.Empty;

	private object? _selectedItem;

	private bool _ignoreSelection;

	public abstract QuickSearchType SearchType { get; }

	public abstract IQuickSearchPreviewVM PreviewVM { get; }

	public SearchContext? Context
	{
		get
		{
			return _context;
		}
		set
		{
			_context = value;
			ContextUpdated();
			OnPropertyChanged("FooterText");
		}
	}

	public virtual bool IsEnabled => true;

	public virtual bool CanDrag => true;

	public virtual bool CanMultiSelect => true;

	public abstract ICollectionView Items { get; }

	public object? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			SetValue<object>("SelectedItem", ref _selectedItem, value, delegate(object o, object n)
			{
				if (!_ignoreSelection)
				{
					OnSelectedItemChanged(o, n);
				}
			});
		}
	}

	public ObservableCollection<object> SelectedItems { get; } = new ObservableCollection<object>();

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

	protected bool IsSearching => !string.IsNullOrWhiteSpace(SearchText);

	public abstract string PlaceholderSearchText { get; }

	public abstract string FooterText { get; }

	public ICommand OpenItemCommand => new RelayCommand(OnOpenItemCommand);

	public ICommand SubmitCommand { get; }

	public virtual bool RequiresAuthentication => false;

	public virtual bool IsAuthenticated => true;

	public event Action? CloseSearch;

	public event Action? SelectAllText;

	protected SearchPageVMBase(ICommand submitCommand)
	{
		SubmitCommand = submitCommand;
	}

	public virtual void OnActivated()
	{
	}

	protected virtual void ContextUpdated()
	{
	}

	protected virtual void OnSelectedItemChanged(object oldItem, object newItem)
	{
	}

	public void DragCompleted()
	{
		if (CanDrag)
		{
			PublishImportEvent(SelectedItems.Count, QuickSearchStyle.DragDrop);
		}
	}

	public void Navigate(bool isForward)
	{
		object[] source = ((IEnumerable)Items).Cast<object>().ToArray();
		object obj = (isForward ? source.GetNext<object>(SelectedItem) : source.GetPrevious<object>(SelectedItem));
		if (obj != null)
		{
			_ignoreSelection = true;
			SelectedItems.Clear();
			SelectedItems.Add(obj);
			_ignoreSelection = false;
			SelectedItem = obj;
		}
	}

	public abstract void RefreshSearch();

	protected abstract void OnItemOpened();

	protected abstract void OnSearchTextChanged(string? _, string searchText);

	private void OnOpenItemCommand()
	{
		if (SelectedItem != null)
		{
			PublishImportEvent(1, QuickSearchStyle.Open);
			OnItemOpened();
		}
	}

	protected void OnCloseSearch()
	{
		this.CloseSearch?.Invoke();
	}

	protected void OnSelectAllText()
	{
		this.SelectAllText?.Invoke();
	}

	protected void PublishExecutedEvent()
	{
		QuickSearchExecutedEvent.Publish(SearchType);
	}

	protected void PublishImportEvent(int count, QuickSearchStyle style)
	{
		QuickSearchImportEvent.Publish(count, SearchType, style);
	}
}
