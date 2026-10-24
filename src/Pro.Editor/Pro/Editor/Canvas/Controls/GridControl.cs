using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Controls;

internal class GridControl : FrameworkElement
{
	private const double LineThickness = 1.0;

	private const double SubThickness = 0.75;

	private const double MinSubSpacing = 5.0;

	public static readonly DependencyProperty CanvasOriginProperty = DependencyProperty.Register("CanvasOrigin", typeof(Vector2<double>), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ScrollHorizontalOffsetProperty = DependencyProperty.Register("ScrollHorizontalOffset", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ScrollVerticalOffsetProperty = DependencyProperty.Register("ScrollVerticalOffset", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ViewportWidthProperty = DependencyProperty.Register("ViewportWidth", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ViewportHeightProperty = DependencyProperty.Register("ViewportHeight", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register("Spacing", typeof(double), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)120.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty SubdivisionsProperty = DependencyProperty.Register("Subdivisions", typeof(int), typeof(GridControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)3, FrameworkPropertyMetadataOptions.AffectsRender));

	public Vector2<double> CanvasOrigin
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(CanvasOriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanvasOriginProperty, (object)value);
		}
	}

	public double ZoomFactor
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomFactorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomFactorProperty, (object)value);
		}
	}

	public double ScrollHorizontalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollHorizontalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollHorizontalOffsetProperty, (object)value);
		}
	}

	public double ScrollVerticalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollVerticalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollVerticalOffsetProperty, (object)value);
		}
	}

	public double ViewportWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ViewportWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportWidthProperty, (object)value);
		}
	}

	public double ViewportHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ViewportHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportHeightProperty, (object)value);
		}
	}

	public Color Color
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorProperty, (object)value);
		}
	}

	public double Spacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpacingProperty, (object)value);
		}
	}

	public int Subdivisions
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SubdivisionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubdivisionsProperty, (object)value);
		}
	}

	public GridControl()
	{
		base.IsHitTestVisible = false;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		if (Color.A <= 0)
		{
			return;
		}
		Rect<double> rect = new Rect<double>(new Vector2<double>(ScrollHorizontalOffset, ScrollVerticalOffset), new Vector2<double>(ViewportWidth, ViewportHeight));
		double num = Spacing * ZoomFactor;
		int num2 = Subdivisions;
		double num3 = num / (double)num2;
		Vector2<double> vector = new Vector2<double>((CanvasOrigin.X - rect.Left).Mod(num) + rect.Left - num, (CanvasOrigin.Y - rect.Top).Mod(num) + rect.Top - num);
		Pen pen = new Pen(new SolidColorBrush(Color), 1.0);
		Pen pen2 = new Pen(new SolidColorBrush(Color), 0.75)
		{
			DashStyle = DashStyles.Dash
		};
		if (num3 < 5.0)
		{
			num2 = 1;
		}
		while (vector.X < rect.Right)
		{
			drawingContext.DrawLine(pen, new Vector2<double>(vector.X, rect.Top), new Vector2<double>(vector.X, rect.Bottom));
			if (num2 >= 2)
			{
				vector.X += num3;
				for (int i = 1; i < num2; i++)
				{
					drawingContext.DrawLine(pen2, new Vector2<double>(vector.X, rect.Top), new Vector2<double>(vector.X, rect.Bottom));
					vector.X += num3;
				}
			}
			else
			{
				vector.X += num;
			}
		}
		while (vector.Y < rect.Bottom)
		{
			drawingContext.DrawLine(pen, new Vector2<double>(rect.Left, vector.Y), new Vector2<double>(rect.Right, vector.Y));
			if (num2 >= 2)
			{
				vector.Y += num3;
				for (int j = 1; j < num2; j++)
				{
					drawingContext.DrawLine(pen2, new Vector2<double>(rect.Left, vector.Y), new Vector2<double>(rect.Right, vector.Y));
					vector.Y += num3;
				}
			}
			else
			{
				vector.Y += num;
			}
		}
	}
}
