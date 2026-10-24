using System.Collections.Generic;
using System.Windows.Media;

namespace ProPresenter.DO.Label;

public static class DefaultColors
{
	public static Color Verse1 => Color.FromArgb(byte.MaxValue, 0, 119, 204);

	public static Color Verse2 => Color.FromArgb(byte.MaxValue, 0, 89, 153);

	public static Color Verse3 => Color.FromArgb(byte.MaxValue, 0, 60, 102);

	public static Color Verse4 => Color.FromArgb(byte.MaxValue, 0, 104, 179);

	public static Color Verse5 => Color.FromArgb(byte.MaxValue, 0, 74, 128);

	public static Color Verse6 => Color.FromArgb(byte.MaxValue, 0, 45, 77);

	public static Color Chorus1 => Color.FromArgb(byte.MaxValue, 204, 0, 78);

	public static Color Chorus2 => Color.FromArgb(byte.MaxValue, 153, 0, 59);

	public static Color Chorus3 => Color.FromArgb(byte.MaxValue, 102, 0, 39);

	public static Color Chorus4 => Color.FromArgb(byte.MaxValue, 179, 0, 68);

	public static Color Bridge1 => Color.FromArgb(byte.MaxValue, 118, 0, 204);

	public static Color Bridge2 => Color.FromArgb(byte.MaxValue, 89, 0, 153);

	public static Color Bridge3 => Color.FromArgb(byte.MaxValue, 59, 0, 102);

	public static Color PreChorus => Color.FromArgb(byte.MaxValue, 204, 41, 139);

	public static Color Tag => Color.FromArgb(byte.MaxValue, 204, 41, 41);

	public static Color Intro => Color.FromArgb(byte.MaxValue, 179, 167, 36);

	public static Color Ending => Color.FromArgb(byte.MaxValue, 153, 143, 31);

	public static Color Outro => Color.FromArgb(byte.MaxValue, 126, 118, 25);

	public static Color Interlude => Color.FromArgb(byte.MaxValue, 36, 179, 76);

	public static Color Blank => Color.FromArgb(byte.MaxValue, 0, 0, 0);

	public static IEnumerable<Color> DefaultLabelColors => new Color[11]
	{
		Colors.Black,
		Colors.Blue,
		Colors.Brown,
		Colors.Cyan,
		Colors.Green,
		Colors.Magenta,
		Colors.Orange,
		Colors.Purple,
		Colors.Red,
		Colors.Yellow,
		Colors.White
	};
}
