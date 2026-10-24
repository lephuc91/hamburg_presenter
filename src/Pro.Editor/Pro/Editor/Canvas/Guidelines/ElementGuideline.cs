using System.Linq;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Guidelines;

internal class ElementGuideline : SnapGuidelineBase
{
	private readonly ElementSL _snapLine;

	private readonly double _nearestEdge;

	private readonly double _farthestEdge;

	public ElementGuideline(ElementSL snapLine, Rect<double> finalBounds)
	{
		_snapLine = snapLine;
		base.IsParent = _snapLine.IsParent;
		_nearestEdge = (snapLine.IsHorizontal ? finalBounds.Left : finalBounds.Top);
		_farthestEdge = (snapLine.IsHorizontal ? finalBounds.Right : finalBounds.Bottom);
	}

	public override void OnRenderGuideline(DrawingContext dc, Pen pen)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		base.OnRenderGuideline(dc, pen);
		double[] source = new double[4] { _snapLine.NearestEdge, _snapLine.FarthestEdge, _nearestEdge, _farthestEdge };
		dc.DrawLine(pen, _snapLine.IsHorizontal.Orient(_snapLine.Position, source.Min()) * base.ZoomFactor, _snapLine.IsHorizontal.Orient(_snapLine.Position, source.Max()) * base.ZoomFactor);
	}
}
