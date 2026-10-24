using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class BubbleProgressControl : Panel
{
	private readonly List<Bubble> _bubbles = new List<Bubble>();

	public static readonly DependencyProperty DefaultFillProperty = DependencyProperty.Register("DefaultFill", typeof(Brush), typeof(BubbleProgressControl));

	public static readonly DependencyProperty ActiveFillProperty = DependencyProperty.Register("ActiveFill", typeof(Brush), typeof(BubbleProgressControl));

	public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(BubbleProgressControl));

	public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register("CurrentValue", typeof(int), typeof(BubbleProgressControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(BubbleProgressControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(MaximumValueChanged)));

	public static readonly DependencyProperty BubbleSizeProperty = DependencyProperty.Register("BubbleSize", typeof(double), typeof(BubbleProgressControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)14.0));

	public static readonly DependencyProperty BubbleSpacingProperty = DependencyProperty.Register("BubbleSpacing", typeof(double), typeof(BubbleProgressControl));

	public static readonly DependencyProperty IsCumulativeProperty = DependencyProperty.Register("IsCumulative", typeof(bool), typeof(BubbleProgressControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty DisplayBubbleViewProperty = DependencyProperty.Register("DisplayBubbleView", typeof(bool), typeof(BubbleProgressControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ClickToValueProperty = DependencyProperty.Register("ClickToValue", typeof(bool), typeof(BubbleProgressControl));

	public Brush DefaultFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DefaultFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultFillProperty, (object)value);
		}
	}

	public Brush ActiveFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveFillProperty, (object)value);
		}
	}

	public Brush Stroke
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(StrokeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeProperty, (object)value);
		}
	}

	public int CurrentValue
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CurrentValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentValueProperty, (object)value);
		}
	}

	public int Maximum
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public double BubbleSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BubbleSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BubbleSizeProperty, (object)value);
		}
	}

	public double BubbleSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BubbleSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BubbleSpacingProperty, (object)value);
		}
	}

	public bool IsCumulative
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCumulativeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCumulativeProperty, (object)value);
		}
	}

	public bool DisplayBubbleView
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayBubbleViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayBubbleViewProperty, (object)value);
		}
	}

	public bool ClickToValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClickToValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClickToValueProperty, (object)value);
		}
	}

	private static void MaximumValueChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((BubbleProgressControl)(object)callerObject).OnMaximumValueChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (_bubbles.Count > 0)
		{
			_bubbles.ForEach(delegate(Bubble b)
			{
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				b.Measure(new Vector2<double>(double.PositiveInfinity));
			});
			double x = _bubbles.Sum(delegate(Bubble b)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				Size desiredSize = b.DesiredSize;
				return ((Size)(ref desiredSize)).Width;
			}) + (double)(_bubbles.Count - 1) * BubbleSpacing;
			Bubble? bubble = _bubbles.FirstOrDefault();
			double y;
			if (bubble == null)
			{
				y = 0.0;
			}
			else
			{
				Size desiredSize2 = bubble.DesiredSize;
				y = ((Size)(ref desiredSize2)).Height;
			}
			Vector2<double> vector = new Vector2<double>(x, y);
			DisplayBubbleView = vector.X <= ((Size)(ref availableSize)).Width;
			return vector;
		}
		return Vector2<double>.Zero;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> zero = Vector2<double>.Zero;
		for (int i = 0; i < _bubbles.Count; i++)
		{
			Bubble bubble = _bubbles[i];
			bubble.IsActive = (IsCumulative ? (i + 1 <= CurrentValue) : (i + 1 == CurrentValue));
			bubble.Arrange(new Rect<double>(zero, (Vector2<double>)bubble.DesiredSize));
			double x = zero.X;
			Size desiredSize = bubble.DesiredSize;
			zero.X = x + (((Size)(ref desiredSize)).Width + BubbleSpacing);
		}
		return base.ArrangeOverride(finalSize);
	}

	private void OnMaximumValueChanged(int oldValue, int newValue)
	{
		int num = newValue - oldValue;
		for (int i = 0; i < num.Abs(); i++)
		{
			if (num < 0)
			{
				RemoveBubble();
			}
			else
			{
				AddBubble();
			}
		}
	}

	private void AddBubble()
	{
		Bubble bubble = new Bubble
		{
			DataContext = this
		};
		bubble.PreviewMouseDown += Bubble_PreviewMouseDown;
		_bubbles.Add(bubble);
		base.Children.Add(bubble);
	}

	private void RemoveBubble()
	{
		Bubble bubble = _bubbles.LastOrDefault();
		if (bubble != null)
		{
			bubble.PreviewMouseDown -= Bubble_PreviewMouseDown;
			base.Children.Remove(bubble);
			_bubbles.Remove(bubble);
		}
	}

	private void Bubble_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		if (ClickToValue && sender is Bubble item)
		{
			int num = _bubbles.IndexOf(item);
			if (num >= 0)
			{
				CurrentValue = num + 1;
			}
		}
	}
}
