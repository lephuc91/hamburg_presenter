using System;

namespace ProPresenter.DO.Themes;

public class ThemeImportedEventArgs : EventArgs
{
	public ImportedThemeModel ImportedThemeModel { get; }

	public ThemeImportedEventArgs(ImportedThemeModel importedThemeModel)
	{
		ImportedThemeModel = importedThemeModel;
	}
}
