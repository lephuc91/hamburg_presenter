using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Calendar;

public class CalendarPrompt : ICalendarPrompt
{
	public bool ConfirmUpdateEvent(out bool updateFutureEvents)
	{
		EventChangeButtons eventChangeButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_title"), LocalizedStrings.Get("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_description"), EventChangeButtons.Cancel | EventChangeButtons.FutureEvents | EventChangeButtons.OnlyThis, EventChangeButtons.OnlyThis) ?? EventChangeButtons.Cancel;
		updateFutureEvents = eventChangeButtons == EventChangeButtons.FutureEvents;
		return eventChangeButtons != EventChangeButtons.Cancel;
	}

	public bool ConfirmUpdateEventType()
	{
		return MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_TYPE_title"), LocalizedStrings.Get("CALENDAR_VIEW_ALERT_CHANGE_REPEAT_EVENT_TYPE_description"));
	}

	public bool ConfirmRemoveEvent(out bool removeAllOccurrences)
	{
		EventChangeButtons eventChangeButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("CALENDAR_VIEW_ALERT_DELETE_REPEAT_EVENT_title"), LocalizedStrings.Get("CALENDAR_VIEW_ALERT_DELETE_REPEAT_EVENT_description"), EventChangeButtons.Cancel | EventChangeButtons.AllOccurrences | EventChangeButtons.OnlyThisOccurrence, EventChangeButtons.OnlyThisOccurrence) ?? EventChangeButtons.Cancel;
		removeAllOccurrences = eventChangeButtons == EventChangeButtons.AllOccurrences;
		return eventChangeButtons != EventChangeButtons.Cancel;
	}
}
