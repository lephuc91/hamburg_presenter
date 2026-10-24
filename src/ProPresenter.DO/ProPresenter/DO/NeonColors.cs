using System.Windows.Media;

namespace ProPresenter.DO;

public static class NeonColors
{
	public static readonly Color[] ColorPalette = new Color[9]
	{
		Color.FromRgb(byte.MaxValue, 235, 75),
		Color.FromRgb(byte.MaxValue, 100, 100),
		Color.FromRgb(15, 230, 145),
		Color.FromRgb(245, 165, 10),
		Color.FromRgb(80, 180, 250),
		Color.FromRgb(230, 50, 180),
		Color.FromRgb(120, 235, 240),
		Color.FromRgb(160, 105, byte.MaxValue),
		Color.FromRgb(140, 250, 60)
	};
}
