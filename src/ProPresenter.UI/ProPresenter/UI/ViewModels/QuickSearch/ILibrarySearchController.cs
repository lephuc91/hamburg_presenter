using System.ComponentModel;
using System.Windows.Input;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public interface ILibrarySearchController : INotifyPropertyChanged
{
	ICommand OpenItemCommand { get; }

	ICommand AddToPlaylistCommand { get; }
}
