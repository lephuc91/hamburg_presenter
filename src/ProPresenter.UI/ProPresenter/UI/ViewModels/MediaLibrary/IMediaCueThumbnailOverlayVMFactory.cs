using System.Windows.Input;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaCueThumbnailOverlayVMFactory
{
	IMediaCueThumbnailOverlayVM? Create(ProPresenterCue? cue, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null);

	IMediaCueThumbnailOverlayVM Create(ProPresenterMacro macro, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null);

	IMediaCueThumbnailOverlayVM Create(INotifyEnumerableChanged<IAction> actions, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null);

	IMediaCueThumbnailOverlayVM? Create(IThumbnailSource? thumbnailSource);
}
