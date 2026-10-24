using System.ComponentModel;
using Pro.Common.Collections;

namespace ProPresenter.UI.ViewModels.Settings.Search;

public interface ISettingsSearchVM : INotifyPropertyChanged
{
	string SearchText { get; set; }

	bool IsSearching { get; }

	ISettingsSearchResultItemVM ActiveItem { get; set; }

	ISettingsSearchResultItemVM SelectedItem { get; set; }

	INotifyEnumerableChanged<ISettingsSearchResultItemVM> SearchResults { get; }
}
