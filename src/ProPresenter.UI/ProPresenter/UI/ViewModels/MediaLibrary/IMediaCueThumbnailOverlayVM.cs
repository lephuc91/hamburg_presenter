using ProPresenter.UI.ViewModels.Thumbnails;
using Reactive.Bindings;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaCueThumbnailOverlayVM : IMediaOverlayVM
{
	ReadOnlyReactivePropertySlim<InvalidMediaType> InvalidMediaType { get; }
}
