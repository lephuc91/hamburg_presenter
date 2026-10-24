using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class TabControlHelper
{
	private const string DisableArrowNavigation = "DisableArrowNavigation";

	public static readonly DependencyProperty DisableArrowNavigationProperty = DependencyProperty.RegisterAttached("DisableArrowNavigation", typeof(bool), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(DisableArrowNavigationChanged)));

	private static void DisableArrowNavigationChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnDisableArrowNavigationChanged((TabControl)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static bool GetDisableArrowNavigation(TabControl element)
	{
		return (bool)((DependencyObject)element).GetValue(DisableArrowNavigationProperty);
	}

	public static void SetDisableArrowNavigation(TabControl element, bool value)
	{
		((DependencyObject)element).SetValue(DisableArrowNavigationProperty, (object)value);
	}

	private static void OnDisableArrowNavigationChanged(TabControl callerObject, bool newValue)
	{
		if (newValue)
		{
			callerObject.PreviewKeyDown += DisableArrowNav_Element_PreviewKeyDown;
		}
		else
		{
			callerObject.PreviewKeyDown -= DisableArrowNav_Element_PreviewKeyDown;
		}
	}

	private static void DisableArrowNav_Element_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		e.Handled = ((Enum)e.KeyboardDevice.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2) && ((int)e.Key == 23 || (int)e.Key == 25);
	}
}
