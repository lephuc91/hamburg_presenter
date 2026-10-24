using System.Windows;

namespace Pro.UI.Themes;

public class Constants
{
	public static ComponentResourceKey ThemeSlideWidth = new ComponentResourceKey(typeof(Constants), "Constants_ThemeSlideWidth");

	public static ComponentResourceKey ThemeSlideHeight = new ComponentResourceKey(typeof(Constants), "Constants_ThemeSlideHeight");

	public static ComponentResourceKey BorderlessPathButtonPathDefaultSize = new ComponentResourceKey(typeof(Constants), "Constants_BorderlessPathButtonPathDefaultSize");

	public static ComponentResourceKey ItemSpacing => new ComponentResourceKey(typeof(Constants), "Constants_ItemSpacing");

	public static ComponentResourceKey ItemHorizontalMargin => new ComponentResourceKey(typeof(Constants), "Constants_ItemHorizontalMargin");

	public static ComponentResourceKey ItemVerticalMargin => new ComponentResourceKey(typeof(Constants), "Constants_ItemVerticalMargin");

	public static ComponentResourceKey ColumnItemHorizontalWidth => new ComponentResourceKey(typeof(Constants), "Constants_ColumnItemHorizontalWidth");

	public static ComponentResourceKey RowItemVerticalHeight => new ComponentResourceKey(typeof(Constants), "Constants_RowItemVerticalHeight");

	public static ComponentResourceKey WindowCornerRadius => new ComponentResourceKey(typeof(Constants), "Constants_WindowCornerRadius");
}
