using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Props;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Controller;

public interface IEditorService
{
	[Obsolete("Use OutputRepository instead")]
	ssAPIOutput OutputController { get; }

	IOutputRepository OutputRepository { get; }

	IPasteStrategy PasteStrategy { get; }

	Task DrawWebFillAsync(HTMLFill fill, Vector2<double> size);

	void TriggerSlide(ArrangedCue slide, bool overrideEnable, bool suppressGoToNext);

	void TriggerProp(IPropCue prop);

	void AssignStageScreen(ScreenArrangementBase screen, SlideCue slideCue);

	Task<BitmapSource?> GetVisualMediaFullSizeThumbnailAsync(VisualMedia visualMedia, Vector2<double> slideSize);

	Task<BitmapSource?> GetLiveVideoMediaPreviewAsync(LiveVideoMedia liveVideoMedia, Vector2<double> slideSize);
}
