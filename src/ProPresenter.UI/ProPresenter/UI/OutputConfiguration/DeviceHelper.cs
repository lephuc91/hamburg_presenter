using System.ComponentModel;
using System.Windows;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public static class DeviceHelper
{
	private const string ConfiguredPhysicalVisibility = "ConfiguredPhysicalVisibility";

	public static readonly DependencyProperty ConfiguredPhysicalVisibilityProperty = DependencyProperty.RegisterAttached("ConfiguredPhysicalVisibility", typeof(HardwareScreenRectangleOptions), typeof(DeviceHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(ConfiguredPhysicalVisibilityChanged)));

	private static void ConfiguredPhysicalVisibilityChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnConfiguredPhysicalVisibilityChanged((UIElement)(object)callerObject, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue as HardwareScreenRectangleOptions, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as HardwareScreenRectangleOptions);
	}

	public static HardwareScreenRectangleOptions GetConfiguredPhysicalVisibility(UIElement element)
	{
		return (HardwareScreenRectangleOptions)((DependencyObject)element).GetValue(ConfiguredPhysicalVisibilityProperty);
	}

	public static void SetConfiguredPhysicalVisibility(UIElement element, HardwareScreenRectangleOptions value)
	{
		((DependencyObject)element).SetValue(ConfiguredPhysicalVisibilityProperty, (object)value);
	}

	private static void OnConfiguredPhysicalVisibilityChanged(UIElement element, HardwareScreenRectangleOptions? oldOptions, HardwareScreenRectangleOptions? newOptions)
	{
		if (oldOptions != null)
		{
			oldOptions.PropertyChanged -= options_PropertyChanged;
		}
		if (newOptions != null)
		{
			newOptions.PropertyChanged += options_PropertyChanged;
		}
		SetElementVisibility(element, newOptions);
		void options_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (sender is HardwareScreenRectangleOptions options)
			{
				string propertyName = e.PropertyName;
				if (propertyName == "IsConfigured" || propertyName == "OutputDevice")
				{
					SetElementVisibility(element, options);
				}
			}
		}
	}

	private static void SetElementVisibility(UIElement element, HardwareScreenRectangleOptions? options)
	{
		((DependencyObject)element).SetCurrentValue(UIElement.VisibilityProperty, (object)((options == null || !options.CanSetVideoDelay()) ? Visibility.Collapsed : Visibility.Visible));
	}
}
