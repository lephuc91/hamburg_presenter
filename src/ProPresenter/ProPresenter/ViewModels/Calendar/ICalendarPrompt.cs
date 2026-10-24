namespace ProPresenter.ViewModels.Calendar;

public interface ICalendarPrompt
{
	bool ConfirmRemoveEvent(out bool removeAllOccurrences);

	bool ConfirmUpdateEvent(out bool updateFutureEvents);

	bool ConfirmUpdateEventType();
}
