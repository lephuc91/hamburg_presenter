using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Pro.Common.Mathematics;
using Pro.UI.Controls.Primitives;
using Pro.UI.Converters;

namespace Pro.UI.Controls;

public class RangeSlider : FrameworkElement
{
	private readonly List<FrameworkElement> _children = new List<FrameworkElement>();

	private readonly Checkerboard _checkerBoard = new Checkerboard
	{
		SquareSize = 4.0
	};

	private readonly Rectangle _gradientRect = new Rectangle();

	private readonly Rectangle _draggableRect = new Rectangle();

	private readonly UnitsThumb _leftThumb = new UnitsThumb
	{
		Units = "%"
	};

	private readonly UnitsThumb _rightThumb = new UnitsThumb
	{
		Units = "%"
	};

	private double _higherRebound;

	private double _lowerRebound;

	private double _rectMousePos;

	private bool _dragInProgress;

	private Vector2<double> _mousePos;

	public static readonly DependencyProperty LowerValueProperty;

	public static readonly DependencyProperty HigherValueProperty;

	public static readonly DependencyProperty LowerColorProperty;

	public static readonly DependencyProperty HigherColorProperty;

	public static readonly DependencyProperty RangeColorProperty;

	public static readonly DependencyProperty MinimumProperty;

	public static readonly DependencyProperty MaximumProperty;

	public static readonly DependencyProperty ValueLinkedProperty;

	public static readonly DependencyProperty PrimaryCheckerboardBrushProperty;

	public static readonly DependencyProperty SecondaryCheckerboardBrushProperty;

	public double LowerValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LowerValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerValueProperty, (object)value);
		}
	}

	public double HigherValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HigherValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherValueProperty, (object)value);
		}
	}

	public Color LowerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(LowerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerColorProperty, (object)value);
		}
	}

	public Color HigherColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(HigherColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherColorProperty, (object)value);
		}
	}

	public Color RangeColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(RangeColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RangeColorProperty, (object)value);
		}
	}

	public double Minimum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public double Maximum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public bool ValueLinked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ValueLinkedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueLinkedProperty, (object)value);
		}
	}

	public Brush PrimaryCheckerboardBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PrimaryCheckerboardBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrimaryCheckerboardBrushProperty, (object)value);
		}
	}

	public Brush SecondaryCheckerboardBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(SecondaryCheckerboardBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryCheckerboardBrushProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => _children.Count;

	static RangeSlider()
	{
		LowerValueProperty = DependencyProperty.Register("LowerValue", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		HigherValueProperty = DependencyProperty.Register("HigherValue", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		LowerColorProperty = DependencyProperty.Register("LowerColor", typeof(Color), typeof(RangeSlider));
		HigherColorProperty = DependencyProperty.Register("HigherColor", typeof(Color), typeof(RangeSlider));
		RangeColorProperty = DependencyProperty.Register("RangeColor", typeof(Color), typeof(RangeSlider));
		MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0));
		MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0));
		ValueLinkedProperty = DependencyProperty.Register("ValueLinked", typeof(bool), typeof(RangeSlider));
		PrimaryCheckerboardBrushProperty = DependencyProperty.Register("PrimaryCheckerboardBrush", typeof(Brush), typeof(RangeSlider));
		SecondaryCheckerboardBrushProperty = DependencyProperty.Register("SecondaryCheckerboardBrush", typeof(Brush), typeof(RangeSlider));
		FrameworkElement.MinHeightProperty.OverrideMetadata(typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)8.0));
	}

	public RangeSlider()
	{
		_checkerBoard.SetBinding(Checkerboard.PrimaryBrushProperty, GetBinding("PrimaryCheckerboardBrush"));
		_checkerBoard.SetBinding(Checkerboard.SecondaryBrushProperty, GetBinding("SecondaryCheckerboardBrush"));
		_draggableRect.Fill = Brushes.Transparent;
		_gradientRect.Fill = new LinearGradientBrush(new GradientStopCollection
		{
			GenerateStop("LowerColor", "Minimum"),
			GenerateStop("RangeColor", "LowerValue"),
			GenerateStop("RangeColor", "HigherValue"),
			GenerateStop("HigherColor", "Maximum")
		});
		SetupThumb(_leftThumb);
		SetupThumb(_rightThumb);
		_gradientRect.PreviewMouseDown += SnapToMouse;
		SetupRect(_draggableRect);
		_draggableRect.SetBinding(UIElement.IsHitTestVisibleProperty, new Binding("ValueLinked")
		{
			Source = this,
			Converter = new InvertedBooleanConverter()
		});
		_leftThumb.SetBinding(UnitsThumb.ValueProperty, new Binding("LowerValue")
		{
			Source = this,
			Converter = new PercentageConverter(),
			Mode = BindingMode.TwoWay
		});
		_rightThumb.SetBinding(UnitsThumb.ValueProperty, new Binding("HigherValue")
		{
			Source = this,
			Converter = new PercentageConverter(),
			Mode = BindingMode.TwoWay
		});
		AddChild(_checkerBoard);
		AddChild(_gradientRect);
		AddChild(_draggableRect);
		AddChild(_leftThumb);
		AddChild(_rightThumb);
	}

	private Binding GetBinding(string path)
	{
		return new Binding(path)
		{
			Source = this
		};
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		_leftThumb.Measure(new Vector2<double>(double.PositiveInfinity));
		_rightThumb.Measure(new Vector2<double>(double.PositiveInfinity));
		return new Vector2<double>((base.HorizontalAlignment == HorizontalAlignment.Stretch && ((Size)(ref availableSize)).Width.IsReal()) ? ((Size)(ref availableSize)).Width : (base.Width.IsReal() ? base.Width : 0.0), (base.VerticalAlignment == VerticalAlignment.Stretch && ((Size)(ref availableSize)).Height.IsReal()) ? ((Size)(ref availableSize)).Height : (base.Height.IsReal() ? base.Height : 0.0));
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		Size desiredSize = base.DesiredSize;
		double desiredWidth = ((Size)(ref desiredSize)).Width;
		desiredSize = base.DesiredSize;
		double desiredHeight = ((Size)(ref desiredSize)).Height;
		_checkerBoard.Arrange(new Rect<double>((Vector2<double>)base.DesiredSize));
		_gradientRect.Arrange(new Rect<double>((Vector2<double>)base.DesiredSize));
		_draggableRect.Arrange(new Rect<double>(desiredWidth * LowerValue, 0.0, desiredWidth * (HigherValue - LowerValue), desiredHeight));
		_leftThumb.Arrange(new Rect<double>(thumbPosition(_leftThumb, LowerValue), thumbSize(_leftThumb)));
		_rightThumb.Arrange(new Rect<double>(thumbPosition(_rightThumb, HigherValue), thumbSize(_rightThumb)));
		return base.ArrangeOverride(finalSize);
		Vector2<double> thumbPosition(Thumb thumb, double value)
		{
			return new Vector2<double>((desiredWidth - thumbSize(thumb).X) * value, (desiredHeight - thumbSize(thumb).Y) / 2.0);
		}
		static Vector2<double> thumbSize(Thumb thumb)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return (Vector2<double>)thumb.DesiredSize;
		}
	}

	protected override Visual GetVisualChild(int index)
	{
		return _children[index];
	}

	private void AddChild(FrameworkElement child)
	{
		AddVisualChild(child);
		_children.Add(child);
	}

	private GradientStop GenerateStop(string colorBindingPath, string offsetBindingPath)
	{
		GradientStop gradientStop = new GradientStop();
		BindingOperations.SetBinding((DependencyObject)(object)gradientStop, GradientStop.ColorProperty, GetBinding(colorBindingPath));
		BindingOperations.SetBinding((DependencyObject)(object)gradientStop, GradientStop.OffsetProperty, GetBinding(offsetBindingPath));
		return gradientStop;
	}

	private void SetupThumb(Thumb thumb)
	{
		thumb.PreviewMouseDown += Thumb_PreviewMouseDown;
		thumb.DragStarted += Thumb_DragStarted;
		thumb.DragCompleted += Thumb_DragCompleted;
		thumb.DragDelta += Thumb_DragDelta;
	}

	private void SetupRect(Rectangle rect)
	{
		rect.MouseDown += Rect_MouseDown;
		rect.MouseMove += Rect_MouseMove;
		rect.MouseUp += Rect_MouseUp;
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		_mousePos = (Vector2<double>)e.GetPosition(this);
	}

	private void Thumb_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		Thumb thumb = sender as Thumb;
		UnitsThumb unitsThumb = ((thumb == _leftThumb) ? _rightThumb : _leftThumb);
		if (ThumbsCompletelyOverlap())
		{
			_leftThumb.CanShowPopup = false;
			_rightThumb.CanShowPopup = false;
		}
		else if (ThumbsPartiallyOverlap(thumb, unitsThumb))
		{
			e.Handled = true;
			ClickThumb(unitsThumb);
		}
		else
		{
			_leftThumb.CanShowPopup = true;
			_rightThumb.CanShowPopup = true;
		}
	}

	private void Thumb_DragStarted(object? sender, DragStartedEventArgs e)
	{
		_lowerRebound = LowerValue;
		_higherRebound = HigherValue;
	}

	private void Thumb_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (!(sender is UnitsThumb unitsThumb))
		{
			return;
		}
		if (!_dragInProgress && ThumbsCompletelyOverlap())
		{
			double x = _mousePos.X;
			Point position = Mouse.GetPosition(this);
			UnitsThumb unitsThumb2 = ((x > ((Point)(ref position)).X) ? _leftThumb : _rightThumb);
			if (unitsThumb != unitsThumb2)
			{
				e.Handled = true;
				unitsThumb2.CanShowPopup = true;
				ClickThumb(unitsThumb2);
				return;
			}
		}
		unitsThumb.CanShowPopup = true;
		unitsThumb.ShowPopup();
		_dragInProgress = true;
		double trackValue = GetTrackValue();
		if (unitsThumb == _leftThumb)
		{
			if (!ValueLinked)
			{
				((DependencyObject)this).SetCurrentValue(HigherValueProperty, (object)Math.Max(trackValue, _higherRebound));
			}
			((DependencyObject)this).SetCurrentValue(LowerValueProperty, (object)trackValue);
		}
		else if (unitsThumb == _rightThumb)
		{
			if (!ValueLinked)
			{
				((DependencyObject)this).SetCurrentValue(LowerValueProperty, (object)Math.Min(trackValue, _lowerRebound));
			}
			((DependencyObject)this).SetCurrentValue(HigherValueProperty, (object)trackValue);
		}
	}

	private bool ThumbsPartiallyOverlap(Thumb? t1, Thumb? t2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> b = (Vector2<double>)Mouse.GetPosition(this);
		return center(t2).Distance(b) < center(t1).Distance(b);
		Vector2<double> center(Thumb? thumb)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return (Vector2<double>)(thumb?.TranslatePoint((Vector2<double>)thumb.RenderSize / 2.0, this) ?? ((Point)Vector2<double>.Zero));
		}
	}

	private bool ThumbsCompletelyOverlap()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		double num = (getPos(_leftThumb) - getPos(_rightThumb)).X.Abs();
		Size renderSize = _leftThumb.RenderSize;
		double width = ((Size)(ref renderSize)).Width;
		renderSize = _rightThumb.RenderSize;
		return num <= (width - ((Size)(ref renderSize)).Width).Abs();
		Vector2<double> getPos(Thumb thumb)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			return (Vector2<double>)thumb.TranslatePoint(Vector2<double>.Zero, this);
		}
	}

	private void Thumb_DragCompleted(object? sender, DragCompletedEventArgs e)
	{
		_dragInProgress = false;
		_lowerRebound = (_higherRebound = 0.0);
	}

	private void Rect_MouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		_rectMousePos = ((Vector2<double>)e.GetPosition(this)).X;
		(sender as UIElement)?.CaptureMouse();
	}

	private void Rect_MouseMove(object? sender, MouseEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			double num = ((Vector2<double>)e.GetPosition(this)).X.Clamp(0.0, base.ActualWidth);
			double delta = (_rectMousePos - num) / base.ActualWidth;
			ParallelValueChange(delta);
			_rectMousePos = num;
		}
	}

	private void Rect_MouseUp(object? sender, MouseButtonEventArgs e)
	{
		(sender as UIElement)?.ReleaseMouseCapture();
	}

	private double GetTrackValue(Func<IInputElement, Point>? getPoint = null)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Point val = (getPoint ?? new Func<IInputElement, Point>(Mouse.GetPosition))(this);
		return (((Point)(ref val)).X / base.ActualWidth).Clamp(Minimum, Maximum);
	}

	private void SnapToMouse(object _, MouseButtonEventArgs e)
	{
		e.Handled = true;
		double trackValue = GetTrackValue(e.GetPosition);
		bool flag = trackValue > Maximum / 2.0;
		((DependencyObject)this).SetCurrentValue(flag ? HigherValueProperty : LowerValueProperty, (object)trackValue);
		ClickThumb(flag ? _rightThumb : _leftThumb);
	}

	private void ParallelValueChange(double delta)
	{
		if (LowerValue - delta < Minimum)
		{
			delta = LowerValue - Minimum;
		}
		else if (HigherValue - delta > Maximum)
		{
			delta = HigherValue - Maximum;
		}
		double num = LowerValue - delta;
		double num2 = HigherValue - delta;
		((DependencyObject)this).SetCurrentValue(LowerValueProperty, (object)num);
		((DependencyObject)this).SetCurrentValue(HigherValueProperty, (object)num2);
	}

	private static void ClickThumb(Thumb thumb)
	{
		thumb.RaiseEvent(getEvent(Mouse.MouseDownEvent));
		static MouseButtonEventArgs getEvent(RoutedEvent @event)
		{
			return new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
			{
				RoutedEvent = @event
			};
		}
	}
}
