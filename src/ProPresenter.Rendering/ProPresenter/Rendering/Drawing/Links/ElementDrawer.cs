using System.Windows.Media;
using Pro.Common.Collections;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Rendering.Drawing.Links;

internal class ElementDrawer : LinkFillDrawerBase
{
	protected override bool EditorResolvedContent => true;

	public override void Draw(DrawingContext dc, RenderingMode renderMode, ILinkedFillObject data, DrawingParams drawingParams)
	{
		bool flag = false;
		if (!drawingParams.RenderingMode.IsOutputMode() && data is ElementLinkedFillObject elementLinkedFillObject)
		{
			IFill fill = elementLinkedFillObject.GetFill(null);
			ClosedBezierPath element = elementLinkedFillObject.Element;
			if (element != null && (!element.FillLink.IsEnabled || element.FillLink.LinkedObject == null) && fill != null && fill.IsEnabled && fill.Type.IsAnyOf(FillType.Solid, FillType.Gradient, FillType.Media))
			{
				fill.OnSizeChanged(drawingParams.Path.Size, drawingParams.Path.Size);
				drawingParams.Drawers.GetFillDrawer(fill.Type)?.Draw(dc, renderMode, fill, drawingParams);
				flag = true;
			}
		}
		if (!flag)
		{
			dc.DrawGeometry(Brushes.Black, null, drawingParams.FillGeometry);
		}
		base.Draw(dc, renderMode, data, drawingParams);
	}
}
