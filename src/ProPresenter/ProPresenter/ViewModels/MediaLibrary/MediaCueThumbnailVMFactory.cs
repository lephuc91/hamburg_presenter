using System.Windows.Input;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaCueThumbnailVMFactory : IMediaCueThumbnailVMFactory
{
	private readonly IMediaCueThumbnailOverlayVMFactory _overlayVMFactory;

	private readonly ICommand _openLiveVideoSetupCommand;

	public MediaCueThumbnailVMFactory(IMediaCueThumbnailOverlayVMFactory overlayVMFactory, ICommand openLiveVideoSetupCommand)
	{
		_overlayVMFactory = overlayVMFactory;
		_openLiveVideoSetupCommand = openLiveVideoSetupCommand;
	}

	public IMediaCueThumbnailVM Create(MediaCue mediaCue)
	{
		return new MediaCueThumbnailVM(mediaCue, _overlayVMFactory.Create(mediaCue, OverlayType.CenterClickable, _openLiveVideoSetupCommand));
	}
}
