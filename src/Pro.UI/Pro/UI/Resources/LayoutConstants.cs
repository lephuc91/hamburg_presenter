using System.Windows;

namespace Pro.UI.Resources;

public static class LayoutConstants
{
	public const double GridSplitterThickness = 8.0;

	private const double GridSplitterMarginValue = -4.0;

	public static readonly Thickness GridSplitterVerticalMargin = new Thickness(0.0, -4.0, 0.0, -4.0);

	public static readonly Thickness GridSplitterHorizontalMargin = new Thickness(-4.0, 0.0, -4.0, 0.0);
}
