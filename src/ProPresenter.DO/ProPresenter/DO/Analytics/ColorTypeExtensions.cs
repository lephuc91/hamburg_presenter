using System.Windows.Media;

namespace ProPresenter.DO.Analytics;

public static class ColorTypeExtensions
{
	public static ColorType ToColorType(this Color? color)
	{
		if (color.HasValue && !(color == Colors.Transparent))
		{
			return ColorType.Other;
		}
		return ColorType.Clear;
	}
}
