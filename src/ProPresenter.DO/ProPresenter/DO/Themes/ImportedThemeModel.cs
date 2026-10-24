using System;

namespace ProPresenter.DO.Themes;

public class ImportedThemeModel
{
	public string ThemeName { get; }

	public DateTime DateImported { get; }

	public bool UserAcknowledgedImportIndicator { get; }

	public bool HasUserViewedThemeDetails { get; }

	public ImportedThemeModel(string themeName, DateTime dateImported, bool userAcknowledgedImportIndicator, bool hasUserViewedThemeDetails)
	{
		ThemeName = themeName;
		DateImported = dateImported;
		UserAcknowledgedImportIndicator = userAcknowledgedImportIndicator;
		HasUserViewedThemeDetails = hasUserViewedThemeDetails;
	}
}
