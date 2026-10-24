using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Updates;

public interface IAvailableUpdateVM : INotifyPropertyChanged
{
	string Title { get; }

	string Version { get; }

	string ButtonName { get; }

	IRelayCommand ButtonCommand { get; }

	IRelayCommand ShowReleaseNotesCommand { get; }
}
