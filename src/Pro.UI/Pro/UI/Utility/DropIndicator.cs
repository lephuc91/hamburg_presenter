using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Utility;

public class DropIndicator : Adorner
{
	private const double CornerRadius = 6.0;

	private AdornerPosition _position;

	private Pen _pen;

	private double _offset;

	public DropIndicator(FrameworkElement adornedElement, AdornerPosition position, double offset = 0.0)
		: this(adornedElement, position, Colors.White, 2.0, offset)
	{
	}

	public DropIndicator(FrameworkElement adornedElement, AdornerPosition position, Color color, double thickness, double offset = 0.0)
		: base(adornedElement)
	{
		_position = position;
		_pen = new Pen(new SolidColorBrush
		{
			Color = color
		}, thickness);
		_offset = offset;
		base.IsHitTestVisible = false;
		base.IsClipEnabled = true;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement obj = (FrameworkElement)base.AdornedElement;
		double actualWidth = obj.ActualWidth;
		double actualHeight = obj.ActualHeight;
		switch (_position)
		{
		case AdornerPosition.Left:
			drawingContext.DrawLine(_pen, new Vector2<double>(0.0 - _offset, 0.0), new Vector2<double>(0.0 - _offset, actualHeight));
			break;
		case AdornerPosition.Top:
			drawingContext.DrawLine(_pen, new Vector2<double>(0.0, 0.0 - _offset), new Vector2<double>(actualWidth, 0.0 - _offset));
			break;
		case AdornerPosition.Right:
			drawingContext.DrawLine(_pen, new Vector2<double>(actualWidth + _offset, 0.0), new Vector2<double>(actualWidth + _offset, actualHeight));
			break;
		case AdornerPosition.Bottom:
			drawingContext.DrawLine(_pen, new Vector2<double>(0.0, actualHeight + _offset), new Vector2<double>(actualWidth, actualHeight + _offset));
			break;
		case AdornerPosition.Inside:
			drawingContext.DrawRoundedRectangle(null, _pen, new Rect<double>(Vector2<double>.Zero, new Vector2<double>(actualWidth, actualHeight)).Pad(_offset), 6.0, 6.0);
			break;
		}
		base.OnRender(drawingContext);
	}
}
