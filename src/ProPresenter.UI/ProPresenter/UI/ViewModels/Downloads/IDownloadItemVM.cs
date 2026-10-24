using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Cache;
using Pro.Common.Downloads;
using Reactive.Bindings;

namespace ProPresenter.UI.ViewModels.Downloads;

public interface IDownloadItemVM : INotifyPropertyChanged, IDisposable
{
	ReadOnlyReactivePropertySlim<string> Name { get; }

	int PercentComplete { get; }

	string ReceivedStatus { get; }

	DownloadStatus Status { get; }

	IAsyncValue<BitmapSource?> Thumbnail { get; }

	IRelayCommand CancelDownloadCommand { get; }

	IRelayCommand RetryDownloadCommand { get; }
}
