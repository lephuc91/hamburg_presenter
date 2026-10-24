using Pro.Data.SQLite;

namespace Pro.Data.Entities;

[Table("ThemePickerSettings")]
public class ThemePickerSettings : EntityBase<ThemePickerSettings>
{
	[Unique]
	public int ContextualGroupId { get; set; }

	public bool MediaActionEnabled { get; set; } = true;

	public ThemePickerSettings()
	{
	}

	public ThemePickerSettings(int contextualGroupName)
	{
		ContextualGroupId = contextualGroupName;
	}
}
