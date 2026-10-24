using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.DO;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public interface IQuickSearchPageVM : INotifyPropertyChanged
{
	QuickSearchType SearchType { get; }

	IQuickSearchPreviewVM PreviewVM { get; }

	SearchContext? Context { get; set; }

	bool IsEnabled { get; }

	bool CanDrag { get; }

	string SearchText { get; set; }

	string PlaceholderSearchText { get; }

	string FooterText { get; }

	ICollectionView Items { get; }

	object? SelectedItem { get; set; }

	ObservableCollection<object> SelectedItems { get; }

	ICommand OpenItemCommand { get; }

	bool RequiresAuthentication { get; }

	bool IsAuthenticated { get; }

	event Action CloseSearch;

	event Action SelectAllText;

	void Navigate(bool isForward);

	void OnActivated();

	void DragCompleted();

	void RefreshSearch();
}
