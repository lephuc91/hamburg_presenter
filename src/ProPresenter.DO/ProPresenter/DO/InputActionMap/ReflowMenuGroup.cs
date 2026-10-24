using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class ReflowMenuGroup : InputActionGroupBase
{
	public InputAction Bold { get; }

	public InputAction Italic { get; }

	public InputAction Underline { get; }

	public InputAction StrikeThrough { get; }

	public InputAction Bigger { get; }

	public InputAction Smaller { get; }

	public ReflowMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		Bold = Add("MAIN_MENU_EDITOR_TEXT_BOLD_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BOLD_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.B, (ModifierKeys)2).ToEnumerable());
		Italic = Add("MAIN_MENU_EDITOR_TEXT_ITALIC_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ITALIC_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.I, (ModifierKeys)2).ToEnumerable());
		Underline = Add("MAIN_MENU_EDITOR_TEXT_UNDERLINE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_UNDERLINE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.U, (ModifierKeys)2).ToEnumerable());
		StrikeThrough = Add("MAIN_MENU_EDITOR_TEXT_STRIKETHROUGH_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_STRIKETHROUGH_title"));
		Bigger = Add("MAIN_MENU_EDITOR_TEXT_BIGGER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BIGGER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Plus, (ModifierKeys)2).ToEnumerable());
		Smaller = Add("MAIN_MENU_EDITOR_TEXT_SMALLER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SMALLER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Minus, (ModifierKeys)2).ToEnumerable());
	}

	protected override bool CanConflict(InputActionGroupBase other)
	{
		if (!(other is EditorMenuGroup))
		{
			return !(other is PresentationMenuGroup);
		}
		return false;
	}
}
