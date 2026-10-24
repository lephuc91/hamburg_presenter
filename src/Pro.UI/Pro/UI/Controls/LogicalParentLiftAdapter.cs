using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class LogicalParentLiftAdapter : FrameworkElement
{
	private UIElement? _child;

	public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(LogicalParentLiftAdapter), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnContentChanged)));

	protected override int VisualChildrenCount => (_child != null) ? 1 : 0;

	public object Content
	{
		get
		{
			return ((DependencyObject)this).GetValue(ContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentProperty, value);
		}
	}

	private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LogicalParentLiftAdapter)(object)d).ContentChanged();
	}

	private void ContentChanged()
	{
		if (_child != null)
		{
			RemoveVisualChild(_child);
		}
		_child = Content as UIElement;
		if (_child != null)
		{
			AddVisualChild(_child);
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		_child?.Measure(availableSize);
		return _child?.DesiredSize ?? base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		_child?.Arrange(new Rect(finalSize));
		return _child?.RenderSize ?? base.ArrangeOverride(finalSize);
	}

	protected override Visual? GetVisualChild(int index)
	{
		return _child;
	}
}
