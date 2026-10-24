using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Props;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.UI.LiveVideo;

namespace ProPresenter.ViewModels;

public class EditorService : IEditorService
{
	private readonly ICoreManager _manager;

	private readonly IMetadataLoader _metadataLoader;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly ITriggering _service;

	public IPasteStrategy PasteStrategy { get; }

	public ssAPIOutput OutputController { get; }

	public IOutputRepository OutputRepository { get; }

	public EditorService(ICoreManager manager, ssAPIOutput outputController, IOutputRepository outputRepository, IPasteStrategy pasteStrategy, IMetadataLoader metadataLoader, IUiDispatcher uiDispatcher, ITriggeringFactory triggeringFactory)
	{
		_manager = manager;
		_metadataLoader = metadataLoader;
		_uiDispatcher = uiDispatcher;
		_service = triggeringFactory.Create();
		OutputController = outputController;
		OutputRepository = outputRepository;
		PasteStrategy = pasteStrategy;
	}

	public async Task DrawWebFillAsync(HTMLFill fill, Vector2<double> size)
	{
		await Task.CompletedTask;
	}

	public void TriggerSlide(ArrangedCue slide, bool overrideEnable, bool suppressGoToNext)
	{
		_service.TriggerSlide(slide, new SlideTriggerOptions(overrideEnable, suppressGoToNext));
	}

	public void TriggerProp(IPropCue prop)
	{
		_service.TriggerProp(prop);
	}

	public void AssignStageScreen(ScreenArrangementBase screen, SlideCue slideCue)
	{
		_manager.OutputConfiguration.StageScreenLayoutMap.AssignScreen(screen, slideCue);
	}

	public async Task<BitmapSource?> GetVisualMediaFullSizeThumbnailAsync(VisualMedia visualMedia, Vector2<double> slideSize)
	{
		if (visualMedia != null)
		{
			MediaMetadataRequest request = new MediaMetadataRequest(visualMedia.ContainerId, visualMedia.ID, visualMedia.SourceFile, visualMedia.ThumbnailPosition, visualMedia.Drawing.Effects, visualMedia.Drawing.CropEnable ? visualMedia.Drawing.CropInsets : new CropInsets(), visualMedia.Drawing.FlipVertically, visualMedia.Drawing.FlipHorizontally, visualMedia.Drawing.NativeRotation, isImport: false, nativeRotationInitialized: true, fullSizeImage: true, AlphaType.Straight, slideSize);
			if (await _metadataLoader.LoadMetadataAsync(request) is IMetadataLoader.SuccessfulResult successfulResult)
			{
				return successfulResult.Thumbnail;
			}
		}
		return null;
	}

	public async Task<BitmapSource?> GetLiveVideoMediaPreviewAsync(LiveVideoMedia liveVideoMedia, Vector2<double> slideSize)
	{
		LiveVideoInput input = liveVideoMedia?.LiveVideo?.Input;
		if (input != null)
		{
			return await _uiDispatcher.InvokeAsync(() => new VideoInputPreview
			{
				VideoInput = input
			}.RenderVisual(slideSize, needsLayout: true));
		}
		return null;
	}
}
