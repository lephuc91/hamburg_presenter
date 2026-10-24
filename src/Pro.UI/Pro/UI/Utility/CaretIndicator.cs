using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Pro.Common.Mathematics;

namespace Pro.UI.Utility;

public class CaretIndicator : Adorner
{
	private double _zoomFactor = 1.0;

	private double _caretHeight;

	private Vector2<double> _caretPosition;

	private Color _caretColor;

	public double ZoomFactor
	{
		get
		{
			return _zoomFactor;
		}
		set
		{
			if (value > 0.0)
			{
				_zoomFactor = value;
				InvalidateVisual();
			}
		}
	}

	public CaretIndicator(UIElement adornedElement, double zoomFactor, double caretHeight, Vector2<double> caretPosition, Color caretColor)
		: base(adornedElement)
	{
		base.IsHitTestVisible = false;
		_zoomFactor = zoomFactor;
		_caretHeight = caretHeight;
		_caretPosition = caretPosition;
		_caretColor = caretColor;
		base.Initialized += delegate
		{
			base.IsClipEnabled = true;
		};
		base.Loaded += CaretIndicator_Loaded;
	}

	private void CaretIndicator_Loaded(object? sender, RoutedEventArgs e)
	{
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
		objectAnimationUsingKeyFrames.Duration = new TimeSpan(0, 0, 1);
		objectAnimationUsingKeyFrames.RepeatBehavior = RepeatBehavior.Forever;
		DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame(Visibility.Hidden, new TimeSpan(0, 0, 0, 0, 500));
		objectAnimationUsingKeyFrames.KeyFrames.Add(keyFrame);
		DiscreteObjectKeyFrame keyFrame2 = new DiscreteObjectKeyFrame(Visibility.Visible, new TimeSpan(0, 0, 1));
		objectAnimationUsingKeyFrames.KeyFrames.Add(keyFrame2);
		Storyboard obj = new Storyboard
		{
			Children = { (Timeline)objectAnimationUsingKeyFrames }
		};
		Storyboard.SetTarget((DependencyObject)(object)obj, (DependencyObject)(object)this);
		Storyboard.SetTargetProperty((DependencyObject)(object)objectAnimationUsingKeyFrames, new PropertyPath(UIElement.VisibilityProperty));
		obj.Begin(this);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		base.OnRender(drawingContext);
		drawingContext.DrawLine(new Pen(new SolidColorBrush(_caretColor), 1.0 / ZoomFactor), _caretPosition, _caretPosition + new Vector2<double>(0.0, _caretHeight));
	}
}
