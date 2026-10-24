using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class PieProgress : Shape
{
	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(PieProgress), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public double Value
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	protected override Geometry DefiningGeometry
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			double num = Value.Mod(1.0);
			Vector2<double> vector = (Vector2<double>)base.RenderSize / 2.0;
			Vector2<double> vector2 = new Vector2<double>(vector.X, 0.0);
			Vector2<double> vector3 = vector2.Rotate(vector, num * 360.0);
			PathGeometry pathGeometry = new PathGeometry();
			PathFigure pathFigure = new PathFigure
			{
				StartPoint = vector
			};
			pathFigure.Segments.Add(new LineSegment
			{
				Point = vector2
			});
			pathFigure.Segments.Add(new ArcSegment
			{
				IsLargeArc = (num >= 0.5),
				Point = vector3,
				Size = vector,
				SweepDirection = SweepDirection.Clockwise
			});
			pathGeometry.Figures.Add(pathFigure);
			return pathGeometry;
		}
	}
}
