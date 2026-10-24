using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.DO.Triggering;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaCueThumbnailOverlayVMFactory : IMediaCueThumbnailOverlayVMFactory
{
	private readonly IDownloadManager _downloadManager;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly IRemoteFileLoader _remoteFileLoader;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IUiScheduler _uiScheduler;

	public MediaCueThumbnailOverlayVMFactory(IDownloadManager downloadManager, IFileSelectorService fileSelectorService, IRemoteFileLoader remoteFileLoader, IImportProcessFactory importProcessFactory, IUiScheduler uiScheduler)
	{
		_downloadManager = downloadManager;
		_fileSelectorService = fileSelectorService;
		_remoteFileLoader = remoteFileLoader;
		_importProcessFactory = importProcessFactory;
		_uiScheduler = uiScheduler;
	}

	public IMediaCueThumbnailOverlayVM? Create(ProPresenterCue? cue, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null)
	{
		if (cue == null)
		{
			return null;
		}
		return new MediaCueThumbnailOverlayVM(cue.Actions, _downloadManager, _fileSelectorService, _remoteFileLoader, _importProcessFactory, _uiScheduler, openLiveVideoSetupCommand)
		{
			Type = overlayType
		};
	}

	public IMediaCueThumbnailOverlayVM Create(ProPresenterMacro macro, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null)
	{
		return new MediaCueThumbnailOverlayVM(macro.Actions, _downloadManager, _fileSelectorService, _remoteFileLoader, _importProcessFactory, _uiScheduler, openLiveVideoSetupCommand)
		{
			Type = overlayType
		};
	}

	public IMediaCueThumbnailOverlayVM Create(INotifyEnumerableChanged<IAction> actions, OverlayType overlayType = OverlayType.CenterClickable, ICommand? openLiveVideoSetupCommand = null)
	{
		return new MediaCueThumbnailOverlayVM(actions, _downloadManager, _fileSelectorService, _remoteFileLoader, _importProcessFactory, _uiScheduler, openLiveVideoSetupCommand)
		{
			Type = overlayType
		};
	}

	public IMediaCueThumbnailOverlayVM? Create(IThumbnailSource? thumbnailSource)
	{
		if (thumbnailSource is ArrangedCue arrangedCue)
		{
			return Create(arrangedCue.Source, OverlayType.MissingIconWithScrim);
		}
		return null;
	}
}
