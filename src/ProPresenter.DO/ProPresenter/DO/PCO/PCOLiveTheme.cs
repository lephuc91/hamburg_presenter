using System.ComponentModel;
using Pro.Localization;

namespace ProPresenter.DO.PCO;

public enum PCOLiveTheme
{
	[Description("light")]
	[LocalizedString("FILL_LINK_PLANNING_CENTER_THEME_LIGHT_title")]
	Light,
	[Description("dark")]
	[LocalizedString("FILL_LINK_PLANNING_CENTER_THEME_DARK_title")]
	Dark
}
