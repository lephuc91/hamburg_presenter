using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class NonLeakingTemplateSelectingContentControl : FrameworkElement
{
	private FrameworkElement? _currentChild;

	public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(NonLeakingTemplateSelectingContentControl), new PropertyMetadata
	{
		PropertyChangedCallback = new PropertyChangedCallback(OnContentChanged)
	});

	public static readonly DependencyProperty ContentTemplateSelectorProperty = DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(NonLeakingTemplateSelectingContentControl));

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

	public DataTemplateSelector ContentTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(ContentTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentTemplateSelectorProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => (_currentChild != null) ? 1 : 0;

	private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as NonLeakingTemplateSelectingContentControl)?.OnContentChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void OnContentChanged(object newContent)
	{
		if (_currentChild != null)
		{
			_currentChild.DataContext = null;
			RemoveLogicalChild(_currentChild);
			RemoveVisualChild(_currentChild);
		}
		DataTemplate dataTemplate = ContentTemplateSelector?.SelectTemplate(newContent, (DependencyObject)(object)this);
		_currentChild = ((dataTemplate != null) ? (dataTemplate.LoadContent() as FrameworkElement) : (newContent as FrameworkElement));
		if (_currentChild != null)
		{
			_currentChild.DataContext = newContent;
			AddLogicalChild(_currentChild);
			AddVisualChild(_currentChild);
		}
		InvalidateMeasure();
		InvalidateArrange();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		_currentChild?.Measure(availableSize);
		return _currentChild?.DesiredSize ?? base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		_currentChild?.Arrange(new Rect(0.0, 0.0, ((Size)(ref finalSize)).Width, ((Size)(ref finalSize)).Height));
		return base.ArrangeOverride(finalSize);
	}

	protected override Visual? GetVisualChild(int index)
	{
		if (index != 0)
		{
			return null;
		}
		return _currentChild;
	}
}
