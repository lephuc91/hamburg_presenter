using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Time;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.Rendering;

namespace ProPresenter.UI.SlideEditor;

public partial class SlideElementItem : UserControl, IComponentConnector
{
	private static readonly TimeSlice RenderCooldown = TimeSlice.FromSeconds(0.5);

	private const string HTMLFillIconSource = "/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementWeb.png";

	private const string TextTickerIconSource = "/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementTicker.png";

	private const string LiveVideoIconSource = "/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementVideoInput.png";

	private bool _elementChanged;

	private bool _waitingForPreview;

	private readonly Clock _renderClock = new Clock();

	private static readonly DependencyProperty PreviewImageProperty = DependencyProperty.Register("PreviewImage", typeof(ImageSource), typeof(SlideElementItem));

	private static readonly DependencyProperty PreviewImageAngleProperty = DependencyProperty.Register("PreviewImageAngle", typeof(double), typeof(SlideElementItem));

	private static readonly DependencyProperty IsTextShapeProperty = DependencyProperty.Register("IsTextShape", typeof(bool), typeof(SlideElementItem));

	private BezierPath? Element => base.DataContext as BezierPath;

	private ImageSource? PreviewImage
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(PreviewImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewImageProperty, (object)value);
		}
	}

	private double PreviewImageAngle
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PreviewImageAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewImageAngleProperty, (object)value);
		}
	}

	private bool IsTextShape
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextShapeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTextShapeProperty, (object)value);
		}
	}

	public SlideElementItem()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += (DependencyPropertyChangedEventHandler)delegate(object s, DependencyPropertyChangedEventArgs e)
		{
			OnElementChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as BezierPath, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as BezierPath);
		};
	}

	private void OnElementChanged(BezierPath? oldValue, BezierPath? newValue)
	{
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= OnElementInvalidated;
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += OnElementInvalidated;
		}
		IsTextShape = newValue is TextShape;
		OnElementInvalidated();
	}

	private void OnElementInvalidated()
	{
		if (Element != null)
		{
			_elementChanged = true;
			InvalidateVisual();
		}
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		base.OnRender(drawingContext);
		if (Element == null)
		{
			return;
		}
		if (TryGetIcon(out string source))
		{
			PreviewImageAngle = 0.0;
			PreviewImage = new BitmapImage(new Uri(source, UriKind.Relative));
			return;
		}
		if (!_waitingForPreview && _elementChanged && (!_renderClock.IsRunning || _renderClock.ElapsedTime >= RenderCooldown) && !IsTextShape)
		{
			_waitingForPreview = true;
			BezierPathRenderer.RenderBezierPathDeferred(Element, RenderingMode.Editor, delegate(BezierPath s, RenderingMode r, IBitmapHandle b)
			{
				_waitingForPreview = false;
				_renderClock.Restart();
				PreviewImage = b.BitmapSource;
				PreviewImageAngle = (ExcludeRotation() ? 0.0 : s.Rotation.InvertedCartesianValue);
			});
		}
		_elementChanged = false;
	}

	private bool TryGetIcon([NotNullWhen(true)] out string? source)
	{
		source = null;
		if (IsTextShape)
		{
			return false;
		}
		if (Element is ClosedBezierPath closedBezierPath)
		{
			if (closedBezierPath.Fill is HTMLFill)
			{
				source = "/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementWeb.png";
			}
			else if (closedBezierPath.Fill is LiveVideoFill)
			{
				source = "/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementVideoInput.png";
			}
		}
		return source != null;
	}

	private bool ExcludeRotation()
	{
		if (Element is ClosedBezierPath closedBezierPath)
		{
			if (!(closedBezierPath.Fill is HTMLFill))
			{
				return closedBezierPath.Fill is LiveVideoFill;
			}
			return true;
		}
		return false;
	}
}
