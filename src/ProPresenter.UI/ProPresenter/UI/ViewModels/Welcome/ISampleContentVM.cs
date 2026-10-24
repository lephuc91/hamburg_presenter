using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface ISampleContentVM : INotifyPropertyChanged
{
	double DownloadProgress { get; }

	string DownloadProgressText { get; }

	bool IsDownloading { get; }

	bool HasNetwork { get; }

	IRelayCommand GetSampleContentCommand { get; }

	IRelayCommand OpenProContentCommand { get; }

	IRelayCommand CancelDownloadCommand { get; }
}
