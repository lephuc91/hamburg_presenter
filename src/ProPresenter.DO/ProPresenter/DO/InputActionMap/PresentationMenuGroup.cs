using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class PresentationMenuGroup : InputActionGroupBase
{
	public InputAction NewSlide { get; }

	public InputAction NextSlide { get; }

	public InputAction PreviousSlide { get; }

	public InputAction NextBackground { get; }

	public InputAction PreviousBackground { get; }

	public InputAction OpenClearGroups { get; }

	public InputAction ClearSlide { get; }

	public InputAction ClearMedia { get; }

	public InputAction ClearProps { get; }

	public InputAction ClearAudio { get; }

	public InputAction ClearMessages { get; }

	public InputAction ClearAnnouncements { get; }

	public InputAction ClearToLogo { get; }

	public InputAction ShowTriggeredPresentation { get; }

	public InputAction ShowTriggeredAnnouncement { get; }

	public InputAction RevealInLibrary { get; }

	public InputAction SlideOnStageScreen { get; }

	public PresentationMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		NewSlide = Add("MAIN_MENU_PRESENTATION_NEW_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_NEW_SLIDE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.N, (ModifierKeys)6).ToEnumerable());
		NextSlide = Add("MAIN_MENU_PRESENTATION_NEXT_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_NEXT_SLIDE_title"), new VirtualKeyGesture[2]
		{
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.Right, (ModifierKeys)0),
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.PageDown, (ModifierKeys)0)
		});
		PreviousSlide = Add("MAIN_MENU_PRESENTATION_PREVIOUS_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_PREVIOUS_SLIDE_title"), new VirtualKeyGesture[2]
		{
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.Left, (ModifierKeys)0),
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.PageUp, (ModifierKeys)0)
		});
		NextBackground = Add("MAIN_MENU_PRESENTATION_NEXT_BACKGROUND_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_NEXT_BACKGROUND_title"), new VirtualKeyGesture[2]
		{
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.Right, (ModifierKeys)1),
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.PageDown, (ModifierKeys)1)
		});
		PreviousBackground = Add("MAIN_MENU_PRESENTATION_PREVIOUS_BACKGROUND_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_PREVIOUS_BACKGROUND_title"), new VirtualKeyGesture[2]
		{
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.Left, (ModifierKeys)1),
			VirtualKeyGesture.CreateKeyGesture(VirtualKey.PageUp, (ModifierKeys)1)
		});
		OpenClearGroups = Add("MAIN_MENU_PRESENTATION_CONFIGURE_CLEAR_GROUPS_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CONFIGURE_CLEAR_GROUPS_title"));
		ClearSlide = Add("MAIN_MENU_PRESENTATION_CLEAR_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_SLIDE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F2, (ModifierKeys)0).ToEnumerable());
		ClearMedia = Add("MAIN_MENU_PRESENTATION_CLEAR_MEDIA_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_MEDIA_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F3, (ModifierKeys)0).ToEnumerable());
		ClearProps = Add("MAIN_MENU_PRESENTATION_CLEAR_PROPS_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_PROPS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F4, (ModifierKeys)0).ToEnumerable());
		ClearAudio = Add("MAIN_MENU_PRESENTATION_CLEAR_AUDIO_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_AUDIO_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F5, (ModifierKeys)0).ToEnumerable());
		ClearMessages = Add("MAIN_MENU_PRESENTATION_CLEAR_MESSAGES_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_MESSAGES_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F6, (ModifierKeys)0).ToEnumerable());
		ClearAnnouncements = Add("MAIN_MENU_PRESENTATION_CLEAR_ANNOUNCEMENTS_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_ANNOUNCEMENTS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F7, (ModifierKeys)0).ToEnumerable());
		ClearToLogo = Add("MAIN_MENU_PRESENTATION_CLEAR_TO_LOGO_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_TO_LOGO_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F12, (ModifierKeys)0).ToEnumerable());
		ShowTriggeredPresentation = Add("MAIN_MENU_PRESENTATION_SHOW_TRIGGERED_PRESENTATION_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_SHOW_TRIGGERED_PRESENTATION_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.L, (ModifierKeys)2).ToEnumerable());
		ShowTriggeredAnnouncement = Add("MAIN_MENU_PRESENTATION_SHOW_TRIGGERED_ANNOUNCEMENT_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_SHOW_TRIGGERED_ANNOUNCEMENT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.L, (ModifierKeys)6).ToEnumerable());
		RevealInLibrary = Add("MAIN_MENU_PRESENTATION_REVEAL_IN_LIBRARY_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_REVEAL_IN_LIBRARY_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.L, (ModifierKeys)3).ToEnumerable());
		SlideOnStageScreen = Add("MAIN_MENU_PRESENTATION_SLIDE_ON_STAGE_SCREEN_ONLY_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_SLIDE_ON_STAGE_SCREEN_ONLY_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D0, (ModifierKeys)2).ToEnumerable());
	}
}
