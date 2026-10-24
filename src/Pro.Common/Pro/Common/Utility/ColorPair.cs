using System.Windows.Media;

namespace Pro.Common.Utility;

public struct ColorPair
{
	public Color? OldColor { get; }

	public Color? NewColor { get; }

	public ColorPair(Color? oldColor, Color? newColor)
	{
		OldColor = oldColor;
		NewColor = newColor;
	}
}
