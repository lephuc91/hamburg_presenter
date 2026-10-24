using System.Windows;
using System.Windows.Documents;

namespace Pro.UI.Utility;

public static class UIElementExtensions
{
	public static bool IsReceivingInput(this UIElement element)
	{
		if (!element.IsFocused && !element.IsKeyboardFocused && !element.IsKeyboardFocusWithin && !element.IsMouseCaptured)
		{
			return element.IsMouseCaptureWithin;
		}
		return true;
	}

	public static AdornerLayer? GetAdornerLayer(this UIElement element)
	{
		return AdornerLayer.GetAdornerLayer(element);
	}

	public static bool AddAdorner(this UIElement element, Adorner? adorner)
	{
		AdornerLayer adornerLayer = element.GetAdornerLayer();
		if (adornerLayer == null || adorner == null)
		{
			return false;
		}
		adornerLayer.Add(adorner);
		return true;
	}

	public static void RemoveAdorner(this UIElement element, Adorner? adorner)
	{
		element.GetAdornerLayer()?.Remove(adorner);
	}
}
