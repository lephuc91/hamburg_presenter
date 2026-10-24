using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class CalendarMenuGroup : InputActionGroupBase
{
	public InputAction Enable { get; }

	public InputAction NewEvent { get; }

	public CalendarMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		Enable = Add("MAIN_MENU_CALENDAR_ENABLE_title", LocalizedStrings.Get("MAIN_MENU_CALENDAR_ENABLE_title"));
		NewEvent = Add("MAIN_MENU_CALENDAR_NEW_EVENT_title", LocalizedStrings.Get("MAIN_MENU_CALENDAR_NEW_EVENT_title"));
	}
}
