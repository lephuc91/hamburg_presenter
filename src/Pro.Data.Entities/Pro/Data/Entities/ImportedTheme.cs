using System;
using Pro.Data.SQLite;

namespace Pro.Data.Entities;

[Table("ImportedThemes")]
public class ImportedTheme : EntityBase<ImportedTheme>
{
	public string ThemeName { get; set; } = string.Empty;

	public DateTime DateImported { get; set; }

	public bool UserAcknowledgedImportIndicator { get; set; }

	public bool HasUserViewedThemeDetails { get; set; }
}
