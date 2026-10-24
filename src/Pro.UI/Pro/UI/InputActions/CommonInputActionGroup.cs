using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;

namespace Pro.UI.InputActions;

public class CommonInputActionGroup : InputActionGroupBase, ICommonInputActionGroup
{
	public InputAction NavigateUp { get; }

	public InputAction SelectPreviousCommand { get; }

	public InputAction NavigateDown { get; }

	public InputAction SelectNextCommand { get; }

	public InputAction Cut { get; }

	public InputAction Print { get; }

	public InputAction Open { get; }

	public InputAction SelectAll { get; }

	public InputAction Find { get; }

	public InputAction PasteAndMatchStyle { get; }

	public InputAction Duplicate { get; }

	public InputAction DeselectAll { get; }

	public InputAction Rename { get; }

	public InputAction Submit { get; }

	public InputAction Undo { get; }

	public InputAction Redo { get; }

	public InputAction Delete { get; }

	public InputAction Paste { get; }

	public InputAction Copy { get; }

	public InputAction ChangeOutputDestination { get; }

	public CommonInputActionGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		NavigateUp = Add("NavigateUp", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Up, (ModifierKeys)0).ToEnumerable());
		SelectPreviousCommand = Add("SelectPreviousCommand", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Up, (ModifierKeys)4).ToEnumerable());
		NavigateDown = Add("NavigateDown", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Down, (ModifierKeys)0).ToEnumerable());
		SelectNextCommand = Add("SelectNextCommand", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Down, (ModifierKeys)4).ToEnumerable());
		Cut = Add("GLOBAL_CUT_ACTION", LocalizedStrings.Get("GLOBAL_CUT_ACTION"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.X, (ModifierKeys)2).ToEnumerable());
		Print = Add("MAIN_MENU_FILE_PRINT_title", LocalizedStrings.Get("MAIN_MENU_FILE_PRINT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.P, (ModifierKeys)2).ToEnumerable());
		Open = Add("Open", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.I, (ModifierKeys)2).ToEnumerable());
		SelectAll = Add("MAIN_MENU_EDIT_SELECT_ALL_title", LocalizedStrings.Get("MAIN_MENU_EDIT_SELECT_ALL_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.A, (ModifierKeys)2).ToEnumerable());
		Find = Add("MAIN_MENU_EDIT_SEARCH_title", LocalizedStrings.Get("MAIN_MENU_EDIT_SEARCH_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F, (ModifierKeys)2).ToEnumerable());
		PasteAndMatchStyle = Add("GLOBAL_PASTE_AND_MATCH_STYLE_ACTION", LocalizedStrings.Get("GLOBAL_PASTE_AND_MATCH_STYLE_ACTION"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.V, (ModifierKeys)1).ToEnumerable(), LocalizedStrings.Get("GLOBAL_PASTE_ACTION").ToEnumerable());
		Duplicate = Add("MAIN_MENU_EDIT_DUPLICATE_title", LocalizedStrings.Get("MAIN_MENU_EDIT_DUPLICATE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D, (ModifierKeys)2).ToEnumerable());
		DeselectAll = Add("MAIN_MENU_EDIT_DESELECT_ALL_title", LocalizedStrings.Get("MAIN_MENU_EDIT_DESELECT_ALL_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D, (ModifierKeys)6).ToEnumerable());
		Rename = Add("Rename", LocalizedStrings.Get("GLOBAL_RENAME_MENU_ITEM_title"));
		Submit = Add("Submit", string.Empty, VirtualKeyGesture.CreateKeyGesture(VirtualKey.Enter, (ModifierKeys)0).ToEnumerable());
		Undo = Add("UNDO_title", LocalizedStrings.Get("UNDO_title", new object[1] { string.Empty }), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Z, (ModifierKeys)2).ToEnumerable());
		Redo = Add("REDO_title", LocalizedStrings.Get("REDO_title", new object[1] { string.Empty }), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Y, (ModifierKeys)2).ToEnumerable());
		Delete = Add("GLOBAL_DELETE_title", LocalizedStrings.Get("GLOBAL_DELETE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Delete, (ModifierKeys)0).ToEnumerable());
		Paste = Add("GLOBAL_PASTE_ACTION", LocalizedStrings.Get("GLOBAL_PASTE_ACTION"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.V, (ModifierKeys)2).ToEnumerable(), LocalizedStrings.Get("GLOBAL_PASTE_ACTION").ToEnumerable());
		Copy = Add("GLOBAL_COPY_ACTION", LocalizedStrings.Get("GLOBAL_COPY_ACTION"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.C, (ModifierKeys)2).ToEnumerable(), LocalizedStrings.Get("GLOBAL_COPY_ACTION").ToEnumerable());
		ChangeOutputDestination = Add("CHANGE_OUTPUT_DESTINATION_ACTION", LocalizedStrings.Get("LIBRARY_PLAYLIST_ITEMS_CONTEXT_MENU_CONTENT_DESTINATION_title"));
	}
}
