using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class EditMenuGroup : InputActionGroupBase
{
	public InputAction Undo { get; }

	public InputAction Redo { get; }

	public InputAction Cut { get; }

	public InputAction Copy { get; }

	public InputAction CopyTextStyle { get; }

	public InputAction Paste { get; }

	public InputAction PasteMatchTextStyle { get; }

	public InputAction PasteTextStyle { get; }

	public InputAction Duplicate { get; }

	public InputAction Delete { get; }

	public InputAction SelectAll { get; }

	public InputAction DeselectAll { get; }

	public InputAction Search { get; }

	public InputAction KeyMapping { get; }

	public EditMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		InputActions obj = parent as InputActions;
		obj.ThrowWhenNull("parentInputActions");
		CommonInputActionGroup commonInputActions = obj.CommonInputActions;
		Undo = commonInputActions.Undo;
		Insert(base.Count, Undo);
		Redo = commonInputActions.Redo;
		Insert(base.Count, Redo);
		Cut = commonInputActions.Cut;
		Insert(base.Count, Cut);
		Copy = commonInputActions.Copy;
		Insert(base.Count, Copy);
		CopyTextStyle = Add("MAIN_MENU_EDIT_COPY_COPY_TEXT_STYLE_title", LocalizedStrings.Get("MAIN_MENU_EDIT_COPY_COPY_TEXT_STYLE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.C, (ModifierKeys)5).ToEnumerable(), LocalizedStrings.Get("GLOBAL_COPY_ACTION").ToEnumerable());
		Paste = commonInputActions.Paste;
		Insert(base.Count, Paste);
		PasteMatchTextStyle = commonInputActions.PasteAndMatchStyle;
		Insert(base.Count, PasteMatchTextStyle);
		PasteTextStyle = Add("MAIN_MENU_EDIT_PASTE_PASTE_TEXT_STYLE_title", LocalizedStrings.Get("MAIN_MENU_EDIT_PASTE_PASTE_TEXT_STYLE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.V, (ModifierKeys)5).ToEnumerable(), LocalizedStrings.Get("GLOBAL_PASTE_ACTION").ToEnumerable());
		Duplicate = commonInputActions.Duplicate;
		Insert(base.Count, Duplicate);
		Delete = commonInputActions.Delete;
		Insert(base.Count, Delete);
		SelectAll = commonInputActions.SelectAll;
		Insert(base.Count, SelectAll);
		DeselectAll = commonInputActions.DeselectAll;
		Insert(base.Count, DeselectAll);
		Search = commonInputActions.Find;
		Insert(base.Count, Search);
		KeyMapping = Add("MAIN_MENU_APPLICATION_KEY_MAPPINGS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_KEY_MAPPINGS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.K, (ModifierKeys)1).ToEnumerable());
	}
}
