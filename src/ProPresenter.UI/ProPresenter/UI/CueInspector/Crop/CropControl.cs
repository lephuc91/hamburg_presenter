using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Controls;

namespace ProPresenter.UI.CueInspector.Crop;

public class CropControl : FixedControl
{
	private const double MinCropSize = 10.0;

	private static readonly Brush FillBackground = new SolidColorBrush(Colors.White)
	{
		Opacity = 0.5
	};

	private readonly CropWindow _cropWindow = new CropWindow();

	public static readonly DependencyProperty CropPositionProperty = DependencyProperty.Register("CropPosition", typeof(Vector2<double>), typeof(CropControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Vector2<double>.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCropPositionChanged)));

	public static readonly DependencyProperty CropSizeProperty = DependencyProperty.Register("CropSize", typeof(Vector2<double>), typeof(CropControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Vector2<double>.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCropSizeChanged)));

	public static readonly DependencyProperty MediaSizeProperty = DependencyProperty.Register("MediaSize", typeof(Vector2<double>), typeof(CropControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, new PropertyChangedCallback(OnMediaSizeChanged)));

	public Vector2<double> CropPosition
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(CropPositionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CropPositionProperty, (object)value);
		}
	}

	public Vector2<double> CropSize
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(CropSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CropSizeProperty, (object)value);
		}
	}

	public Vector2<double> MediaSize
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(MediaSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaSizeProperty, (object)value);
		}
	}

	private static void OnCropPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CropControl)(object)d).UpdateWindow();
	}

	private static void OnCropSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CropControl)(object)d).UpdateWindow();
	}

	private static void OnMediaSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CropControl)(object)d).UpdateWindow();
	}

	public CropControl()
	{
		_cropWindow.WindowMoved += OnWindowMoved;
		base.Children.Add(_cropWindow);
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> rect = new Rect<double>((Vector2<double>)_cropWindow.TranslatePoint(Vector2<double>.Zero, this), (Vector2<double>)_cropWindow.RenderSize);
		Rect<double> rect2 = new Rect<double>((Vector2<double>)base.RenderSize);
		dc.PushClip(new CombinedGeometry(GeometryCombineMode.Exclude, new RectangleGeometry(rect2), new RectangleGeometry(rect)));
		dc.DrawRectangle(FillBackground, null, rect2);
		dc.Pop();
	}

	private void UpdateWindow()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		UpdateWindow((Vector2<double>)base.RenderSize);
	}

	private void UpdateWindow(Vector2<double> size)
	{
		if (size.X != 0.0 && size.Y != 0.0)
		{
			Vector2<double> vector = MediaSize.ScaleToFitSize(size);
			double num = MediaSize.ScaleToFitScalar(size);
			base.Origin = (size - vector) / 2.0;
			base.LocationScale = num;
			_cropWindow.Location = CropPosition;
			_cropWindow.Width = CropSize.X * num;
			_cropWindow.Height = CropSize.Y * num;
			_cropWindow.CropSize = CropSize;
			_cropWindow.MediaSize = MediaSize;
			DoInvalidateVisual();
		}
	}

	private void DoInvalidateVisual()
	{
		_cropWindow.InvalidateVisual();
		InvalidateVisual();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		base.MeasureOverride(availableSize);
		if (!((Size)(ref availableSize)).Width.IsReal() || !((Size)(ref availableSize)).Height.IsReal())
		{
			return Vector2<double>.One;
		}
		return availableSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Size result = base.ArrangeOverride(finalSize);
		UpdateWindow((Vector2<double>)finalSize);
		return result;
	}

	private void OnWindowMoved(Vector2<double> position, Vector2<double> size)
	{
		Rect<double> rect = new Rect<double>(position, size).Abs();
		if (rect.Width >= 10.0 && rect.Height >= 10.0)
		{
			((DependencyObject)this).SetCurrentValue(CropPositionProperty, (object)position);
			((DependencyObject)this).SetCurrentValue(CropSizeProperty, (object)size);
		}
	}
}
