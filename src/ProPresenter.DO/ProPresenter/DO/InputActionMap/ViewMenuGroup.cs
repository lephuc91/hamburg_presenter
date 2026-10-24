using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class ViewMenuGroup : InputActionGroupBase
{
	public InputAction Show { get; }

	public InputAction TogglePresentationEditor { get; }

	public InputAction ShowPresentationEditor { get; }

	public InputAction ToggleReflowEditor { get; }

	public InputAction ShowReflowEditor { get; }

	public InputAction ToggleBibles { get; }

	public InputAction ShowBibles { get; }

	public InputAction ContinuousPlaylist { get; }

	public InputAction AudioBin { get; }

	public InputAction Stage { get; }

	public InputAction Timers { get; }

	public InputAction Messages { get; }

	public InputAction Props { get; }

	public InputAction Macros { get; }

	public InputAction Timecode { get; }

	public InputAction PlanningCenter { get; }

	public InputAction ProContent { get; }

	public InputAction ToggleMediaBin { get; }

	public InputAction Calendar { get; }

	public InputAction ActionPalette { get; }

	public InputAction TestPatterns { get; }

	public InputAction Downloads { get; }

	public InputAction OpenProPresenterControl { get; }

	public InputAction GridView { get; }

	public InputAction EasyView { get; }

	public InputAction TableView { get; }

	public ViewMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		Show = Add("MAIN_MENU_VIEW_SHOW_title", LocalizedStrings.Get("MAIN_MENU_VIEW_SHOW_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.S, (ModifierKeys)2).ToEnumerable());
		TogglePresentationEditor = Add("MAIN_MENU_VIEW_PRESENTATION_EDITOR_title", LocalizedStrings.Get("MAIN_MENU_VIEW_PRESENTATION_EDITOR_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.E, (ModifierKeys)2).ToEnumerable());
		ShowPresentationEditor = CreateInputAction("MAIN_MENU_VIEW_PRESENTATION_EDITOR_title", LocalizedStrings.Get("MAIN_MENU_VIEW_PRESENTATION_EDITOR_title"));
		ToggleReflowEditor = Add("MAIN_MENU_VIEW_REFLOW_EDITOR_title", LocalizedStrings.Get("MAIN_MENU_VIEW_REFLOW_EDITOR_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.R, (ModifierKeys)2).ToEnumerable());
		ShowReflowEditor = CreateInputAction("MAIN_MENU_VIEW_REFLOW_EDITOR_title", LocalizedStrings.Get("MAIN_MENU_VIEW_REFLOW_EDITOR_title"));
		ToggleBibles = Add("MAIN_MENU_VIEW_BIBLES_title", LocalizedStrings.Get("MAIN_MENU_VIEW_BIBLES_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.B, (ModifierKeys)7).ToEnumerable());
		ShowBibles = CreateInputAction("MAIN_MENU_VIEW_BIBLES_title", LocalizedStrings.Get("MAIN_MENU_VIEW_BIBLES_title"));
		ContinuousPlaylist = Add("MAIN_MENU_VIEW_CONTINUOUS_PLAYLIST", LocalizedStrings.Get("MAIN_MENU_VIEW_CONTINUOUS_PLAYLIST"));
		GridView = Add("MAIN_MENU_VIEW_SLIDE_VIEW_GRID_VIEW_title", LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_GRID_VIEW_title"), null, new global::_003C_003Ez__ReadOnlySingleElementList<string>(LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_title")));
		EasyView = Add("MAIN_MENU_VIEW_SLIDE_VIEW_EASY_VIEW_title", LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_EASY_VIEW_title"), null, new global::_003C_003Ez__ReadOnlySingleElementList<string>(LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_title")));
		TableView = Add("MAIN_MENU_VIEW_SLIDE_VIEW_TABLE_VIEW_title", LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_TABLE_VIEW_title"), null, new global::_003C_003Ez__ReadOnlySingleElementList<string>(LocalizedStrings.Get("MAIN_MENU_VIEW_SLIDE_VIEW_title")));
		AudioBin = Add("MAIN_MENU_VIEW_AUDIO_BIN_title", LocalizedStrings.Get("MAIN_MENU_VIEW_AUDIO_BIN_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.A, (ModifierKeys)6).ToEnumerable());
		Stage = Add("MAIN_MENU_VIEW_STAGE_title", LocalizedStrings.Get("MAIN_MENU_VIEW_STAGE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.S, (ModifierKeys)1).ToEnumerable());
		Timers = Add("MAIN_MENU_VIEW_TIMERS_title", LocalizedStrings.Get("MAIN_MENU_VIEW_TIMERS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.C, (ModifierKeys)6).ToEnumerable());
		Messages = Add("MAIN_MENU_VIEW_MESSAGES_title", LocalizedStrings.Get("MAIN_MENU_VIEW_MESSAGES_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.M, (ModifierKeys)2).ToEnumerable());
		Props = Add("MAIN_MENU_VIEW_PROPS_title", LocalizedStrings.Get("MAIN_MENU_VIEW_PROPS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.P, (ModifierKeys)6).ToEnumerable());
		Macros = Add("MAIN_MENU_VIEW_MACROS_title", LocalizedStrings.Get("MAIN_MENU_VIEW_MACROS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.M, (ModifierKeys)6).ToEnumerable());
		Timecode = Add("MAIN_MENU_VIEW_TIMECODE_title", LocalizedStrings.Get("MAIN_MENU_VIEW_TIMECODE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.T, (ModifierKeys)6).ToEnumerable());
		PlanningCenter = Add("MAIN_MENU_VIEW_PLANNING_CENTER_title", LocalizedStrings.Get("MAIN_MENU_VIEW_PLANNING_CENTER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.P, (ModifierKeys)3).ToEnumerable());
		ProContent = Add("GLOBAL_PROCONTENT_NAME", LocalizedStrings.Get("GLOBAL_PROCONTENT_NAME"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.R, (ModifierKeys)6).ToEnumerable());
		ToggleMediaBin = Add("MAIN_MENU_VIEW_MEDIA_BIN_title", LocalizedStrings.Get("MAIN_MENU_VIEW_MEDIA_BIN_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.V, (ModifierKeys)6).ToEnumerable());
		Calendar = Add("MAIN_MENU_VIEW_CALENDAR_title", LocalizedStrings.Get("MAIN_MENU_VIEW_CALENDAR_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.C, (ModifierKeys)3).ToEnumerable());
		ActionPalette = Add("MAIN_MENU_VIEW_ACTION_PALETTE_title", LocalizedStrings.Get("MAIN_MENU_VIEW_ACTION_PALETTE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.A, (ModifierKeys)1).ToEnumerable());
		TestPatterns = Add("MAIN_MENU_VIEW_TEST_PATTERNS_title", LocalizedStrings.Get("MAIN_MENU_VIEW_TEST_PATTERNS_title"));
		Downloads = Add("DOWNLOADS_POPOVER_SHOW_POPOVER_MENU_title", LocalizedStrings.Get("DOWNLOADS_POPOVER_SHOW_POPOVER_MENU_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.J, (ModifierKeys)2).ToEnumerable());
		OpenProPresenterControl = Add("MAIN_MENU_VIEW_PROPRESENTER_CONTROL_title", LocalizedStrings.Get("MAIN_MENU_VIEW_PROPRESENTER_CONTROL_title"));
	}
}
