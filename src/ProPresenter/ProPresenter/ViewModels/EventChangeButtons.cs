using System;
using Pro.Localization;

namespace ProPresenter.ViewModels;

[Flags]
public enum EventChangeButtons
{
	None = 0,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_ALL_FUTURE_EVENTS_BUTTON_title")]
	FutureEvents = 2,
	[LocalizedString("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_ONLY_THIS_EVENT_BUTTON_title")]
	OnlyThis = 4,
	[LocalizedString("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_TYPE_ALL_OCCURRENCES_BUTTON_title")]
	AllOccurrences = 8,
	[LocalizedString("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_TYPE_ONLY_THIS_OCCURRENCE_BUTTON_title")]
	OnlyThisOccurrence = 0x10
}
