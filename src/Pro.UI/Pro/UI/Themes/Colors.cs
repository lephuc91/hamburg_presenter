using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Themes;

public static class Colors
{
	public static ComponentResourceKey Background => new ComponentResourceKey(typeof(Colors), "Color_Background");

	public static ComponentResourceKey CheckerboardLightPrimary => new ComponentResourceKey(typeof(Colors), "Color_CheckerboardLightPrimary");

	public static ComponentResourceKey CheckerboardLightSecondary => new ComponentResourceKey(typeof(Colors), "Color_CheckerboardLightSecondary");

	public static ComponentResourceKey CheckerboardPrimary => new ComponentResourceKey(typeof(Colors), "Color_CheckerboardPrimary");

	public static ComponentResourceKey CheckerboardSecondary => new ComponentResourceKey(typeof(Colors), "Color_CheckerboardSecondary");

	public static ComponentResourceKey ContentHelper => new ComponentResourceKey(typeof(Colors), "Color_ContentHelper");

	public static ComponentResourceKey ContentPrimary => new ComponentResourceKey(typeof(Colors), "Color_ContentPrimary");

	public static ComponentResourceKey ContentSecondary => new ComponentResourceKey(typeof(Colors), "Color_ContentSecondary");

	public static ComponentResourceKey DarkContent => new ComponentResourceKey(typeof(Colors), "Color_DarkContent");

	public static ComponentResourceKey DefaultTextFill => new ComponentResourceKey(typeof(Colors), "Color_DefaultTextFill");

	public static ComponentResourceKey LightContent => new ComponentResourceKey(typeof(Colors), "Color_LightContent");

	public static ComponentResourceKey Overlay => new ComponentResourceKey(typeof(Colors), "Color_Overlay");

	public static ComponentResourceKey Primary => new ComponentResourceKey(typeof(Colors), "Color_Primary");

	public static ComponentResourceKey PrimaryDark => new ComponentResourceKey(typeof(Colors), "Color_PrimaryDark");

	public static ComponentResourceKey PrimaryLight => new ComponentResourceKey(typeof(Colors), "Color_PrimaryLight");

	public static ComponentResourceKey Secondary => new ComponentResourceKey(typeof(Colors), "Color_Secondary");

	public static ComponentResourceKey SecondaryDark => new ComponentResourceKey(typeof(Colors), "Color_SecondaryDark");

	public static ComponentResourceKey SecondaryLight => new ComponentResourceKey(typeof(Colors), "Color_SecondaryLight");

	public static ComponentResourceKey Shadow => new ComponentResourceKey(typeof(Colors), "Color_Shadow");

	public static ComponentResourceKey SpecialTextFillPrimary => new ComponentResourceKey(typeof(Colors), "Color_SpecialTextFillPrimary");

	public static ComponentResourceKey SpecialTextFillSecondary => new ComponentResourceKey(typeof(Colors), "Color_SpecialTextFillSecondary");

	public static ComponentResourceKey StateActive => new ComponentResourceKey(typeof(Colors), "Color_StateActive");

	public static ComponentResourceKey StateCaution => new ComponentResourceKey(typeof(Colors), "Color_StateCaution");

	public static ComponentResourceKey StateError => new ComponentResourceKey(typeof(Colors), "Color_StateError");

	public static ComponentResourceKey Surface => new ComponentResourceKey(typeof(Colors), "Color_Surface");

	public static ComponentResourceKey PopUpWindowOverlay => new ComponentResourceKey(typeof(Colors), "Color_PopUpWindowOverlay");

	public static Color? GetColor(ComponentResourceKey key)
	{
		return Application.Current?.TryFindResource(key) as Color?;
	}
}
