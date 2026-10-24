using System.Windows.Media;

namespace ProPresenter.ViewModels.Settings.Pages;

public static class SettingsListItemConstants
{
	public static readonly Brush Orange = new LinearGradientBrush(Color.FromRgb(254, 120, 78), Color.FromRgb(254, 55, 47), 90.0);

	public static readonly Brush Purple = new LinearGradientBrush(Color.FromRgb(192, 115, byte.MaxValue), Color.FromRgb(145, 30, 241), 90.0);

	public static readonly Brush Blue = new LinearGradientBrush(Color.FromRgb(92, 118, byte.MaxValue), Color.FromRgb(62, 31, byte.MaxValue), 90.0);

	public static readonly Brush Green = new LinearGradientBrush(Color.FromRgb(66, 216, 188), Color.FromRgb(14, 142, 117), 90.0);

	public static readonly Brush Gray = new LinearGradientBrush(Color.FromRgb(146, 146, 146), Color.FromRgb(84, 84, 84), 90.0);

	public static readonly Brush Cyan = new LinearGradientBrush(Color.FromRgb(79, 208, 236), Color.FromRgb(23, 156, 212), 90.0);
}
