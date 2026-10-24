using System;
using Pro.Localization;

namespace ProPresenter.DO.Calendar;

[Flags]
public enum EventDay
{
	Unknown = 0,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_SUNDAY_label")]
	Sunday = 1,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_MONDAY_label")]
	Monday = 2,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_TUESDAY_label")]
	Tuesday = 4,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_WEDNESDAY_label")]
	Wednesday = 8,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_THURSDAY_label")]
	Thursday = 0x10,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_FRIDAY_label")]
	Friday = 0x20,
	[LocalizedString("CALENDAR_VIEW_EVENT_REPEAT_SATURDAY_label")]
	Saturday = 0x40
}
