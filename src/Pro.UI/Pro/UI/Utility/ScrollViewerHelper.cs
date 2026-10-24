using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class ScrollViewerHelper
{
	private const string UseHorizontalScrolling = "UseHorizontalScrolling";

	public static readonly DependencyProperty UseHorizontalScrollingProperty = DependencyProperty.RegisterAttached("UseHorizontalScrolling", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata((object)false, new PropertyChangedCallback(UseHorizontalScrollingChanged)));

	private static void UseHorizontalScrollingChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnUseHorizontalScrollingChanged((UIElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnUseHorizontalScrollingChanged(UIElement element, bool useHorizontalScrolling)
	{
		if (useHorizontalScrolling)
		{
			element.PreviewMouseWheel += OnPreviewMouseWheel;
		}
		else
		{
			element.PreviewMouseWheel -= OnPreviewMouseWheel;
		}
	}

	private static void OnPreviewMouseWheel(object? sender, MouseWheelEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		ScrollViewer scrollViewer = ((DependencyObject)(object)(sender as UIElement))?.FindVisualChild<ScrollViewer>();
		if (scrollViewer != null && ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4))
		{
			scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - (double)e.Delta);
			e.Handled = true;
		}
	}

	public static void SetUseHorizontalScrolling(ItemsControl element, bool value)
	{
		((DependencyObject)element).SetValue(UseHorizontalScrollingProperty, (object)value);
	}

	public static bool GetUseHorizontalScrolling(ItemsControl element)
	{
		return (bool)((DependencyObject)element).GetValue(UseHorizontalScrollingProperty);
	}
}
