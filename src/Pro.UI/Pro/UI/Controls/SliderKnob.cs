using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.UI.Controls;

public class SliderKnob<T> : FrameworkElement where T : notnull
{
	private const double TrackGapAngle = 60.0;

	private const double TrackGapThickness = 1.0;

	private const double InnerRadiusScale = 2.0 / 3.0;

	private bool _isSliding;

	private Vector2<double> _mouseDownPosition = Vector2<double>.Zero;

	private T _mouseDownValue;

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(T), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Constants<T>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(T), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Constants<T>.One, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(T), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(T), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty IncrementScalarProperty = DependencyProperty.Register("IncrementScalar", typeof(T), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Constants<T>.One, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty TrackBackgroundProperty = DependencyProperty.Register("TrackBackground", typeof(Brush), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty TrackFillProperty = DependencyProperty.Register("TrackFill", typeof(Brush), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Blue, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty KnobFillProperty = DependencyProperty.Register("KnobFill", typeof(Brush), typeof(SliderKnob<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightBlue, FrameworkPropertyMetadataOptions.AffectsRender));

	public T Minimum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public T Maximum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public T Value
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public T IncrementScalar
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(IncrementScalarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncrementScalarProperty, (object)value);
		}
	}

	public Brush TrackBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TrackBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TrackBackgroundProperty, (object)value);
		}
	}

	public Brush TrackFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TrackFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TrackFillProperty, (object)value);
		}
	}

	public Brush KnobFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(KnobFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KnobFillProperty, (object)value);
		}
	}

	public SliderKnob()
	{
		UpdateCursor();
	}

	private void UpdateCursor()
	{
		base.Cursor = (_isSliding ? Cursors.ScrollNS : Cursors.Hand);
	}

	protected virtual double ScaleValue(T value)
	{
		return value.ToFeatureRange(Minimum, Maximum).Cast<double, T>();
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Min(base.ActualWidth, base.ActualHeight);
		double num2 = num / 2.0;
		double num3 = num * (2.0 / 3.0) / 2.0;
		Vector2<double> center = new Vector2<double>(num) / 2.0;
		double trackThickness = num2 - num3;
		double trackDiameter = num - trackThickness / 2.0;
		num3 -= 1.0;
		dc.PushTransform(new TranslateTransform((base.ActualWidth - num) / 2.0, (base.ActualHeight - num) / 2.0));
		dc.DrawEllipse(Brushes.Transparent, null, center, num2, num2);
		dc.DrawEllipse(KnobFill, null, center, num3, num3);
		drawTrack(1.0, TrackBackground);
		drawTrack(ScaleValue(Value).Clamp(0.0, 1.0), TrackFill);
		dc.Pop();
		void drawTrack(double value, Brush brush)
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			double num4 = value * 300.0;
			Vector2<double> vector = new Vector2<double>(center.X, trackDiameter).Rotate(center, 30.0);
			Vector2<double> vector2 = vector.Rotate(center, num4);
			PathGeometry pathGeometry = new PathGeometry();
			PathFigure pathFigure = new PathFigure
			{
				StartPoint = vector
			};
			pathFigure.Segments.Add(new ArcSegment
			{
				IsLargeArc = (num4 >= 180.0),
				Point = vector2,
				Size = new Vector2<double>(trackDiameter) - center,
				SweepDirection = SweepDirection.Clockwise,
				IsStroked = true
			});
			pathGeometry.Figures.Add(pathFigure);
			dc.DrawGeometry(null, new Pen(brush, trackThickness), pathGeometry);
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
		{
			_isSliding = true;
			_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
			_mouseDownValue = Value;
			UpdateCursor();
			CaptureMouse();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (_isSliding)
		{
			Vector2<double> vector = _mouseDownPosition - (Vector2<double>)e.GetPosition(this);
			((DependencyObject)this).SetCurrentValue(ValueProperty, (object)_mouseDownValue.Add(vector.Y.Cast<T, double>().Multiply(IncrementScalar)).Clamp(Minimum, Maximum));
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Released)
		{
			_isSliding = false;
			UpdateCursor();
			ReleaseMouseCapture();
		}
	}
}
