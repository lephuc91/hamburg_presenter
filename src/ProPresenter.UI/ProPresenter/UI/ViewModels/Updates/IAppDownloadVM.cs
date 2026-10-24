using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Updates;

public interface IAppDownloadVM : INotifyPropertyChanged
{
	int PercentComplete { get; }

	long BytesDownloaded { get; }

	long TotalBytes { get; }

	bool DownloadComplete { get; }

	bool DownloadSuccessful { get; }

	IRelayCommand CancelCommand { get; }

	IRelayCommand InstallCommand { get; }
}
