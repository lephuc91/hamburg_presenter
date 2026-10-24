using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Utility;

namespace ProPresenter.UI.Thumbnails;

public class SlideGroupPointer : Adorner
{
	private const double TriangleWidth = 24.0;

	private const double TriangleHeight = 24.0;

	private Color _color;

	private readonly AdornerPosition _position;

	public SlideGroupPointer(UIElement adornedElement, Color color, AdornerPosition position)
		: base(adornedElement)
	{
		base.IsHitTestVisible = false;
		base.IsClipEnabled = true;
		_color = color;
		_position = position;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		if (base.AdornedElement is FrameworkElement frameworkElement)
		{
			num = frameworkElement.ActualWidth;
			num2 = frameworkElement.ActualHeight;
		}
		Vector2<double> vector = new Vector2<double>(num / 2.0, num2 / 2.0);
		SolidColorBrush brush = new SolidColorBrush
		{
			Color = _color
		};
		PathFigure pathFigure;
		if (_position == AdornerPosition.Top || _position == AdornerPosition.Bottom)
		{
			bool flag = _position == AdornerPosition.Top;
			pathFigure = new PathFigure(new Vector2<double>(vector.X - 24.0, flag ? 0.0 : num2), new LineSegment[2]
			{
				new LineSegment(new Vector2<double>(vector.X + 24.0, flag ? 0.0 : num2), isStroked: false)
				{
					IsStroked = true
				},
				new LineSegment(new Vector2<double>(vector.X, flag ? 24.0 : (num2 - 24.0)), isStroked: false)
				{
					IsStroked = true
				}
			}, closed: true);
		}
		else
		{
			bool flag2 = _position == AdornerPosition.Right;
			pathFigure = new PathFigure(new Vector2<double>(flag2 ? num : 0.0, vector.Y - 24.0), new LineSegment[2]
			{
				new LineSegment(new Vector2<double>(flag2 ? (num - 24.0) : 24.0, vector.Y), isStroked: false)
				{
					IsStroked = true
				},
				new LineSegment(new Vector2<double>(flag2 ? num : 0.0, vector.Y + 24.0), isStroked: false)
				{
					IsStroked = true
				}
			}, closed: true);
		}
		drawingContext.DrawGeometry(brush, new Pen(new SolidColorBrush
		{
			Color = (_color.IsLuminous() ? Colors.Black : Colors.White)
		}, 1.0), new PathGeometry(new PathFigure[1] { pathFigure }));
		base.OnRender(drawingContext);
	}
}
