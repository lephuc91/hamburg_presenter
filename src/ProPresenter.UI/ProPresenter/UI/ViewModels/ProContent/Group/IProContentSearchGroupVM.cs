using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.ViewModels.ProContent.Group;

public interface IProContentSearchGroupVM : IProContentGroupVM, INavigationItem, INotifyPropertyChanged, IDisposable
{
	string SearchTerm { get; set; }

	bool SearchInProgress { get; }

	IAsyncRelayCommand<bool?> PerformSearchCommand { get; }

	IAsyncRelayCommand ClearSearchCommand { get; }
}
