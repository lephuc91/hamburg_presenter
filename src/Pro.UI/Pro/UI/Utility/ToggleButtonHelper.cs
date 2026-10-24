using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class ToggleButtonHelper
{
	private const string FocusElementOnClick = "FocusElementOnClick";

	public static readonly DependencyProperty FocusElementOnClickProperty = DependencyProperty.RegisterAttached("FocusElementOnClick", typeof(UIElement), typeof(ToggleButtonHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(FocusElementOnClickChanged)));

	private static void FocusElementOnClickChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnFocusElementOnClickChanged((ToggleButton)(object)callerObject, (UIElement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static UIElement? GetFocusElementOnClick(ToggleButton element)
	{
		return (UIElement)((DependencyObject)element).GetValue(FocusElementOnClickProperty);
	}

	public static void SetFocusElementOnClick(ToggleButton element, UIElement? value)
	{
		((DependencyObject)element).SetValue(FocusElementOnClickProperty, (object)value);
	}

	private static void OnFocusElementOnClickChanged(ToggleButton callerObject, UIElement? newValue)
	{
		if (newValue != null)
		{
			callerObject.Click += Button_Click;
		}
		else
		{
			callerObject.Click -= Button_Click;
		}
	}

	private static void Button_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is ToggleButton { IsChecked: var isChecked } toggleButton && isChecked == true)
		{
			UIElement focusElementOnClick = GetFocusElementOnClick(toggleButton);
			if (focusElementOnClick != null)
			{
				focusElementOnClick.Focus();
				Keyboard.Focus(focusElementOnClick);
			}
		}
	}
}
