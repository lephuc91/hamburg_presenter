using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Editor.Canvas.Controls.Trackers;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

public class CanvasRuler : TrackerRuler
{
	private readonly MouseTracker _mouseTracker = new MouseTracker();

	private readonly ObjectTracker _objectTracker = new ObjectTracker();

	private Vector2<double> _startPos;

	private bool _canAddStop = true;

	public static readonly DependencyProperty MousePositionProperty = DependencyProperty.Register("MousePosition", typeof(Vector2<double>), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, new PropertyChangedCallback(MousePositionPropertyChanged)));

	public static readonly DependencyProperty MouseTrackerColorProperty = DependencyProperty.Register("MouseTrackerColor", typeof(Color), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Red, new PropertyChangedCallback(TrackerColorPropertyChanged)));

	public static readonly DependencyProperty ObjectBoundsProperty = DependencyProperty.Register("ObjectBounds", typeof(Rect<double>), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect<double>.Empty, new PropertyChangedCallback(ObjectBoundsPropertyChanged)));

	public static readonly DependencyProperty ObjectBoundsColorProperty = DependencyProperty.Register("ObjectBoundsColor", typeof(Color), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Blue, new PropertyChangedCallback(ObjectBoundsColorPropertyChanged)));

	public static readonly DependencyProperty IsMouseInCanvasProperty = DependencyProperty.Register("IsMouseInCanvas", typeof(bool), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(IsMouseInCanvasPropertyChanged)));

	public static readonly DependencyProperty IsTransformActiveProperty = DependencyProperty.Register("IsTransformActive", typeof(bool), typeof(CanvasRuler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(IsTransformActivePropertyChanged)));

	public static readonly DependencyProperty TabStopsControlProperty = DependencyProperty.Register("TabStopsControl", typeof(TabStopsControl), typeof(CanvasRuler));

	public Vector2<double> MousePosition
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(MousePositionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MousePositionProperty, (object)value);
		}
	}

	public Color MouseTrackerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(MouseTrackerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseTrackerColorProperty, (object)value);
		}
	}

	public Rect<double> ObjectBounds
	{
		get
		{
			return (Rect<double>)((DependencyObject)this).GetValue(ObjectBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ObjectBoundsProperty, (object)value);
		}
	}

	public Color ObjectBoundsColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ObjectBoundsColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ObjectBoundsColorProperty, (object)value);
		}
	}

	public bool IsMouseInCanvas
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMouseInCanvasProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMouseInCanvasProperty, (object)value);
		}
	}

	public bool IsTransformActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTransformActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTransformActiveProperty, (object)value);
		}
	}

	public TabStopsControl? TabStopsControl
	{
		get
		{
			return (TabStopsControl)((DependencyObject)this).GetValue(TabStopsControlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabStopsControlProperty, (object)value);
		}
	}

	private static void MousePositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CanvasRuler)(object)d)._mouseTracker.MousePosition = (Vector2<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	private static void TrackerColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CanvasRuler)(object)d)._mouseTracker.TrackerColor = (Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	private static void ObjectBoundsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CanvasRuler)(object)d)._objectTracker.ObjectBounds = (Rect<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	private static void ObjectBoundsColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CanvasRuler)(object)d)._objectTracker.TrackerColor = (Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	private static void IsMouseInCanvasPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is CanvasRuler canvasRuler && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is bool flag)
		{
			canvasRuler._mouseTracker.IsVisible = flag && !canvasRuler.IsTransformActive;
		}
	}

	private static void IsTransformActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is CanvasRuler canvasRuler && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is bool flag)
		{
			canvasRuler._objectTracker.IsVisible = flag;
			canvasRuler._mouseTracker.IsVisible = !flag && canvasRuler.IsMouseInCanvas;
		}
	}

	public CanvasRuler()
	{
		_mouseTracker.IsVisible = false;
		_objectTracker.IsVisible = false;
		_mouseTracker.TrackerColor = MouseTrackerColor;
		_objectTracker.TrackerColor = ObjectBoundsColor;
		AddTracker(_mouseTracker);
		AddTracker(_objectTracker);
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		if (IsMouseInCanvas && Mouse.LeftButton.HasFlag(MouseButtonState.Pressed))
		{
			(base.DataContext as CanvasControl)?.OnDragFromRuler(base.IsHorizontal);
		}
		ResetTabStops();
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (TabStopsControl != null && e.ChangedButton == MouseButton.Left)
		{
			_startPos = (Vector2<double>)e.GetPosition(this);
			ResetTabStops();
			base.OnMouseDown(e);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (TabStopsControl != null && e.ChangedButton == MouseButton.Left)
		{
			if (CanEditTabStop() && _canAddStop)
			{
				Vector2<double> vector = new Vector2<double>(_startPos.X, 0.0);
				TabStopsControl.AddStopFromRuler((MousePosition == Vector2<double>.Zero) ? vector : MousePosition);
				_canAddStop = false;
			}
			_startPos = Vector2<double>.Zero;
			ResetTabStops();
			base.OnMouseUp(e);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (TabStopsControl == null)
		{
			return;
		}
		Vector2<double> vector = new Vector2<double>(_startPos.X, 0.0);
		Vector2<double> movePos = (Vector2<double>)e.GetPosition(this);
		if (CanEditTabStop() && Mouse.LeftButton.HasFlag(MouseButtonState.Pressed))
		{
			if (_canAddStop)
			{
				if (MouseEventExtensions.CanDrag(new Vector2<double>(movePos.X, 0.0), vector))
				{
					AddStop(vector);
					CaptureMouse();
				}
			}
			else
			{
				TabStopsControl.DragActiveStop(movePos, _startPos);
			}
		}
		base.OnMouseMove(e);
	}

	private void ResetTabStops()
	{
		_canAddStop = true;
		TabStopsControl?.Reset();
		ReleaseMouseCapture();
	}

	private bool CanEditTabStop()
	{
		if (TabStopsControl?.TabStops?.IsEditing == true)
		{
			return base.IsHorizontal;
		}
		return false;
	}

	private void AddStop(Vector2<double> pos)
	{
		if (TabStopsControl != null && _canAddStop)
		{
			TabStopsControl.AddStopFromRuler((MousePosition == Vector2<double>.Zero) ? pos : MousePosition);
			_canAddStop = false;
		}
	}
}
