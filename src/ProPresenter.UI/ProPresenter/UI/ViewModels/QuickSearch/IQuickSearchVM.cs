using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.UI.Components;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public interface IQuickSearchVM : INotifyPropertyChanged
{
	IEnumerable<IQuickSearchPageVM> AvailablePages { get; }

	SearchContext? Context { get; set; }

	string SearchText { get; set; }

	IQuickSearchPageVM? ActivePage { get; set; }

	ICommand<IQuickSearchPageVM> SelectPageCommand { get; }

	event Action CloseSearch;

	event Action SelectAllText;
}
