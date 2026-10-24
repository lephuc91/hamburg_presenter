using System.Windows;

namespace ProPresenter.UI.Utility;

public static class UIHelper
{
	private const string ContentTriggeredString = "ContentTriggered";

	public static readonly DependencyProperty ContentTriggeredProperty = DependencyProperty.RegisterAttached("ContentTriggered", typeof(bool), typeof(UIHelper));

	public static bool GetContentTriggered(DependencyObject element)
	{
		return (bool)element.GetValue(ContentTriggeredProperty);
	}

	public static void SetContentTriggered(DependencyObject element, bool value)
	{
		element.SetValue(ContentTriggeredProperty, (object)value);
	}
}
