using System.Windows;
using System.Windows.Media;

namespace ProPresenter.Rendering;

internal static class RenderConstants
{
	public static SolidColorBrush MaskBrush { get; }

	public static Color MaskColor { get; }

	static RenderConstants()
	{
		MaskColor = Colors.White;
		MaskBrush = new SolidColorBrush(MaskColor);
		((Freezable)MaskBrush).Freeze();
	}
}
