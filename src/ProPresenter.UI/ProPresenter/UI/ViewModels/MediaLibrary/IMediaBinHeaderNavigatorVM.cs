using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaBinHeaderNavigatorVM : INavigationItem, INotifyPropertyChanged
{
	INavigationItem CurrentItem { get; set; }

	ObservableCollection<INavigationItem> SelectedPath { get; }

	IAsyncRelayCommand<INavigationItem> SelectItemCommand { get; }

	IAsyncRelayCommand NavigateBackwardCommand { get; }

	IAsyncRelayCommand NavigateForwardCommand { get; }
}
