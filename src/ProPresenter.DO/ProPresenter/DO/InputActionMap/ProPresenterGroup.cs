using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class ProPresenterGroup : InputActionGroupBase, IProPresenterGroup
{
	public InputAction ConfigureGroupHotkey { get; }

	public InputAction NextSlideWithSuppression { get; }

	public InputAction NewPCOPlaylist { get; }

	public InputAction RefreshPCOPlaylist { get; }

	public InputAction ConvertPCOPlaylist { get; }

	public InputAction OpenPCOAttachmentManager { get; }

	public InputAction AddSelectedCuesToPlaylist { get; }

	public InputAction BreakTextToNewSlide { get; }

	public InputAction BreakTextToNextSlide { get; }

	public InputAction NewTheme { get; }

	public InputAction EditTheme { get; }

	public InputAction DeleteTheme { get; }

	public InputAction AddSelectionToNewTheme { get; }

	public InputAction AddSelectionToTheme { get; }

	public InputAction OpenMediaInspector { get; }

	public InputAction SetMediaInPoint { get; }

	public InputAction SetMediaOutPoint { get; }

	public InputAction AddMediaMarker { get; }

	public InputAction TogglePlaybackState { get; }

	public InputAction PlaybackJumpStart { get; }

	public InputAction PlaybackJumpEnd { get; }

	public InputAction PlaybackJumpBack { get; }

	public InputAction PlaybackJumpForward { get; }

	public ProPresenterGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		ConfigureGroupHotkey = Add("SETTINGS_GROUPS_CONFIGURE_KEY_MAPPINGS_title", LocalizedStrings.Get("SETTINGS_GROUPS_CONFIGURE_KEY_MAPPINGS_title"));
		NextSlideWithSuppression = Add("MAIN_MENU_PRESENTATION_NEXT_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_PRESENTATION_NEXT_SLIDE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Space, (ModifierKeys)0).ToEnumerable());
		NewPCOPlaylist = Add("LIBRARY_PLAYLIST_OUTLINE_NEW_MENU_NEW_PCO_PLAYLIST_FOLDER_title", LocalizedStrings.Get("LIBRARY_PLAYLIST_OUTLINE_NEW_MENU_NEW_PCO_PLAYLIST_FOLDER_title"));
		RefreshPCOPlaylist = Add("LIBRARY_PLAYLIST_REFRESH_PCO_ITEM_title", LocalizedStrings.Get("LIBRARY_PLAYLIST_REFRESH_PCO_ITEM_title"));
		ConvertPCOPlaylist = Add("LIBRARY_PLAYLIST_CONVERT_PCO_PLAYLIST_TO_STANDARD_PLAYLIST_title", LocalizedStrings.Get("LIBRARY_PLAYLIST_CONVERT_PCO_PLAYLIST_TO_STANDARD_PLAYLIST_title"));
		OpenPCOAttachmentManager = Add("OpenPCOAttachmentManager", string.Empty);
		AddSelectedCuesToPlaylist = Add("AddSelectedCuesToPlaylist", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Enter, (ModifierKeys)2).ToEnumerable());
		BreakTextToNewSlide = Add("BreakTextToNewSlide", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Enter, (ModifierKeys)2).ToEnumerable());
		BreakTextToNextSlide = Add("BreakTextToNextSlide", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Enter, (ModifierKeys)6).ToEnumerable());
		NewTheme = Add("THEMES_MENU_NEW_THEME_title", LocalizedStrings.Get("THEMES_MENU_NEW_THEME_title"));
		EditTheme = Add("THEMES_MENU_EDIT_THEME_title", LocalizedStrings.Get("THEMES_MENU_EDIT_THEME_title"));
		DeleteTheme = Add("THEMES_MENU_REMOVE_THEME_title", LocalizedStrings.Get("THEMES_MENU_REMOVE_THEME_title"));
		AddSelectionToNewTheme = Add("THEMES_MENU_NEW_THEME_FROM_SELECTION_title", LocalizedStrings.Get("THEMES_MENU_NEW_THEME_FROM_SELECTION_title"));
		AddSelectionToTheme = Add("THEMES_MENU_ADD_SELECTION_TO_THEME_title", LocalizedStrings.Get("THEMES_MENU_ADD_SELECTION_TO_THEME_title"));
		OpenMediaInspector = Add("MEDIA_BIN_CONTEXT_MENU_INSPECTOR_title", LocalizedStrings.Get("MEDIA_BIN_CONTEXT_MENU_INSPECTOR_title"));
		SetMediaInPoint = Add("SetMediaInPoint", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.I, (ModifierKeys)0).ToEnumerable());
		SetMediaOutPoint = Add("SetMediaOutPoint", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.O, (ModifierKeys)0).ToEnumerable());
		AddMediaMarker = Add("AddMediaMarker", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.M, (ModifierKeys)0).ToEnumerable());
		TogglePlaybackState = Add("TogglePlaybackState", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Space, (ModifierKeys)0).ToEnumerable());
		PlaybackJumpStart = Add("PlaybackJumpStart", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Left, (ModifierKeys)2).ToEnumerable());
		PlaybackJumpEnd = Add("PlaybackJumpEnd", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Right, (ModifierKeys)2).ToEnumerable());
		PlaybackJumpBack = Add("PlaybackJumpBack", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Left, (ModifierKeys)0).ToEnumerable());
		PlaybackJumpForward = Add("PlaybackJumpForward", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Right, (ModifierKeys)0).ToEnumerable());
	}
}
