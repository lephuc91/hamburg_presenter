using System;

namespace ProPresenter.DO.Themes;

public class ThemeUpdatedEventArgs : EventArgs
{
	public string ThemeName { get; }

	public ThemeUpdatedEventArgs(string themeName)
	{
		ThemeName = themeName;
	}
}
