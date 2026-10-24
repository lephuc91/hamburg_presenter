using System.Windows;
using Pro.UI.Themes;

namespace Pro.UI;

public class ThemedWindow : Window
{
	public const string ThemeStyleKeyWindow = "STYLE_ThemedWindow";

	public static ThemedWindowStyleKey StyleKey = new ThemedWindowStyleKey();

	public ThemedWindow()
	{
		Style style = (TryFindResource(StyleKey) as Style) ?? (TryFindResource("STYLE_ThemedWindow") as Style);
		if (style != null)
		{
			base.Style = style;
		}
	}
}
