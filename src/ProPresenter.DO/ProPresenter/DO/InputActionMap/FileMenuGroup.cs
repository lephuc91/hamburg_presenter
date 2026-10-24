using System.Collections.Generic;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class FileMenuGroup : InputActionGroupBase
{
	public InputAction NewPresentation { get; }

	public InputAction NewPlaylist { get; }

	public InputAction NewLibrary { get; }

	public InputAction ImportFile { get; }

	public InputAction ImportTextFromClipboard { get; }

	public InputAction ImportPowerPoint { get; }

	public InputAction ImportPowerPointLegacy { get; }

	public InputAction ImportMultiTracks { get; }

	public InputAction ImportSongSelect { get; }

	public InputAction ImportMedia { get; }

	public InputAction ImportProLibrary { get; }

	public InputAction ExportPresentation { get; }

	public InputAction ExportPresentationBundle { get; }

	public InputAction ExportText { get; }

	public InputAction ExportSlideImages { get; }

	public InputAction ExportPlaylist { get; }

	public InputAction ExportThemes { get; }

	public InputAction Print { get; }

	public FileMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		NewPresentation = Add("MAIN_MENU_FILE_NEW_PRESENTATION_title", LocalizedStrings.Get("MAIN_MENU_FILE_NEW_PRESENTATION_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.N, (ModifierKeys)2).ToEnumerable());
		NewPlaylist = Add("MAIN_MENU_FILE_NEW_PLAYLIST_title", LocalizedStrings.Get("MAIN_MENU_FILE_NEW_PLAYLIST_title"));
		NewLibrary = Add("MAIN_MENU_FILE_NEW_LIBRARY_title", LocalizedStrings.Get("MAIN_MENU_FILE_NEW_LIBRARY_title"));
		IEnumerable<string> accessPath = LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_SUBMENU_title").ToEnumerable();
		ImportFile = Add("MAIN_MENU_FILE_IMPORT_FILE_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_FILE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.I, (ModifierKeys)6).ToEnumerable(), accessPath);
		ImportTextFromClipboard = Add("MAIN_MENU_FILE_IMPORT_TEXT_FROM_CLIPBOARD_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_TEXT_FROM_CLIPBOARD_title"), null, accessPath);
		ImportPowerPoint = Add("MAIN_MENU_FILE_IMPORT_POWERPOINT_AS_PRESENTATION_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_POWERPOINT_AS_PRESENTATION_title"), null, accessPath);
		ImportPowerPointLegacy = Add("MAIN_MENU_FILE_IMPORT_POWERPOINT_AS_IMAGES_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_POWERPOINT_AS_IMAGES_title"), null, accessPath);
		ImportMultiTracks = Add("MAIN_MENU_FILE_IMPORT_MULTITRACKS_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_MULTITRACKS_title"), null, accessPath);
		ImportSongSelect = Add("MAIN_MENU_FILE_IMPORT_SONGSELECT_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_SONGSELECT_title"), null, accessPath);
		ImportMedia = Add("MAIN_MENU_FILE_IMPORT_MEDIA_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_MEDIA_title"), null, accessPath);
		ImportProLibrary = Add("MAIN_MENU_FILE_IMPORT_PROPRESENTER_LIBRARY_title", LocalizedStrings.Get("MAIN_MENU_FILE_IMPORT_PROPRESENTER_LIBRARY_title"), null, accessPath);
		IEnumerable<string> accessPath2 = LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_SUBMENU_title").ToEnumerable();
		ExportPresentation = Add("MAIN_MENU_FILE_EXPORT_PRESENTATION_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_PRESENTATION_title"), null, accessPath2);
		ExportPresentationBundle = Add("MAIN_MENU_FILE_EXPORT_PRESENTATION_BUNDLE_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_PRESENTATION_BUNDLE_title"), null, accessPath2);
		ExportText = Add("MAIN_MENU_FILE_EXPORT_TEXT_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_TEXT_title"), null, accessPath2);
		ExportSlideImages = Add("MAIN_MENU_FILE_EXPORT_SLIDE_IMAGES_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_SLIDE_IMAGES_title"), null, accessPath2);
		ExportPlaylist = Add("MAIN_MENU_FILE_EXPORT_PLAYLIST_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_PLAYLIST_title"), null, accessPath2);
		ExportThemes = Add("MAIN_MENU_FILE_EXPORT_THEMES_title", LocalizedStrings.Get("MAIN_MENU_FILE_EXPORT_THEMES_title"), null, accessPath2);
		InputActions inputActions = parent as InputActions;
		inputActions.ThrowWhenNull("parentInputActions");
		Print = inputActions.CommonInputActions.Print;
		Insert(base.Collection.Count, Print);
	}
}
