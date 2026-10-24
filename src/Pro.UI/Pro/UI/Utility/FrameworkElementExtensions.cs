using System.Windows;

namespace Pro.UI.Utility;

public static class FrameworkElementExtensions
{
	public static T WithDataContext<T>(this T element, object dataContext) where T : FrameworkElement
	{
		element.DataContext = dataContext;
		return element;
	}
}
