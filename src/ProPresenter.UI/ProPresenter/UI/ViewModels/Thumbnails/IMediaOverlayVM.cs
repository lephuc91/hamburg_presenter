using System.Windows.Input;
using Pro.Common.Downloads;
using Reactive.Bindings;

namespace ProPresenter.UI.ViewModels.Thumbnails;

public interface IMediaOverlayVM
{
	OverlayType Type { get; }

	ReadOnlyReactivePropertySlim<bool> IsValid { get; }

	ReadOnlyReactivePropertySlim<DownloadProgress> DownloadProgress { get; }

	ICommand RelinkCommand { get; }

	ICommand DownloadCommand { get; }

	ICommand ReconnectVideoInputCommand { get; }

	ICommand CancelDownloadCommand { get; }
}
