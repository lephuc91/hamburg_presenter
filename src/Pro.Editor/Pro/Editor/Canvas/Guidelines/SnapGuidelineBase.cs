using System.Windows.Media;

namespace Pro.Editor.Canvas.Guidelines;

internal abstract class SnapGuidelineBase : GuidelineBase
{
	public override void OnRenderGuideline(DrawingContext dc, Pen pen)
	{
		dc.PushTransform(new TranslateTransform(base.Origin.X + base.RenderOffset.X, base.Origin.Y + base.RenderOffset.Y));
	}
}
