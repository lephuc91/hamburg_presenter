using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Guidelines;

public class StaticGuideline : GuidelineBase
{
	private const double GrabAreaOffset = 5.0;

	private readonly StaticSL _guide;

	private double ScaledPosition => _guide.Position * base.ZoomFactor;

	private double StartLength
	{
		get
		{
			if (!_guide.IsHorizontal)
			{
				return 0.0 - base.Origin.Y;
			}
			return 0.0 - base.Origin.X;
		}
	}

	public StaticSL Guide => _guide;

	public Rect<double> Bounds => new Rect<double>(_guide.IsHorizontal.Orient(ScaledPosition - 5.0, StartLength), _guide.IsHorizontal.Orient(10.0, _guide.IsHorizontal ? (base.Origin.X * 3.0) : (base.Origin.Y * 3.0)));

	public StaticGuideline(StaticSL guide)
	{
		_guide = guide;
	}

	public override void OnRenderGuideline(DrawingContext dc, Pen pen)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		if (_guide.IsEnabled)
		{
			double magnitude = (_guide.IsHorizontal ? (base.Origin.X * 2.0) : (base.Origin.Y * 2.0));
			dc.PushTransform(new TranslateTransform(base.Origin.X, base.Origin.Y));
			dc.DrawLine(pen, _guide.IsHorizontal.Orient(ScaledPosition, StartLength), _guide.IsHorizontal.Orient(ScaledPosition, magnitude));
			dc.DrawRectangle(Brushes.Transparent, null, Bounds);
		}
	}
}
