using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Slide.Links.Text.Slide;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor;

public class AddElementCommandParameters
{
	public ShapeType? NewShape { get; set; }

	public SlideMenuTextMode? SlideMenuTextMode { get; set; }

	public SlideTargetSourceMode? SlideTargetSourceMode { get; set; }

	public ScreenArrangementBase? ScreenArrangementBase { get; set; }

	public TimerData? TimerData { get; set; }

	public PlaybackMarkerIdentifierType? PlaybackMarkerIdentifierType { get; set; }

	public GroupSourceType? GroupSourceType { get; set; }

	public InsertEditorObjectSourceType InsertionSource { get; set; } = InsertEditorObjectSourceType.None;
}
