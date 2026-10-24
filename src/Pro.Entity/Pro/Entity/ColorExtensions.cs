using System.Windows.Media;
using Pro.Common.Utility;
using Pro.Entity.Properties;

namespace Pro.Entity;

public static class ColorExtensions
{
	public static System.Windows.Media.Color ToColor(this Color? color)
	{
		if ((object)color == null)
		{
			return Colors.Transparent;
		}
		return System.Windows.Media.Color.FromArgb(Pro.Common.Utility.ColorExtensions.ScaleComponent(color.Alpha), Pro.Common.Utility.ColorExtensions.ScaleComponent(color.Red), Pro.Common.Utility.ColorExtensions.ScaleComponent(color.Green), Pro.Common.Utility.ColorExtensions.ScaleComponent(color.Blue));
	}

	public static System.Windows.Media.Color ToColor(this IObservableProperty<Color> color)
	{
		return color.Value.ToColor();
	}

	public static Color ToEntityColor(this System.Windows.Media.Color color)
	{
		return new Color(Pro.Common.Utility.ColorExtensions.NormalizeComponent(color.R), Pro.Common.Utility.ColorExtensions.NormalizeComponent(color.G), Pro.Common.Utility.ColorExtensions.NormalizeComponent(color.B), Pro.Common.Utility.ColorExtensions.NormalizeComponent(color.A));
	}
}
