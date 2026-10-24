using System.ComponentModel;
using Pro.Localization;

namespace ProPresenter.DO.PCO;

public enum PCOLiveCountdownType
{
	[Description("item")]
	[LocalizedString("FILL_LINK_PLANNING_CENTER_TIME_FORMAT_FULL_ITEM_LENGTH_title")]
	FullItemLength,
	[Description("item_adjusted")]
	[LocalizedString("FILL_LINK_PLANNING_CENTER_TIME_FORMAT_END_ITEM_ON_TIME_title")]
	EndItemOnTime,
	[Description("service")]
	[LocalizedString("FILL_LINK_PLANNING_CENTER_TIME_FORMAT_END_SERVICE_ON_TIME_title")]
	EndServiceOnTime
}
