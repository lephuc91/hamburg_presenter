using System;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.KeyMapping;

public class KeyGesturePrompt : IKeyGesturePrompt
{
	public void ShowNeedsModifier(string name)
	{
		MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("KEYMAPPING_PREFERENCES_VALIDATION_MODIFIER_REQUIRED_message", new object[1] { name }));
	}

	public void ShowGestureIsReservedForAlternate(string name, string alternate)
	{
	}

	public bool ShowResetAllConfirmation()
	{
		string message = LocalizedStrings.Get("KEYMAPPING_PREFERENCES_RESET_WARNING_message") + Environment.NewLine + Environment.NewLine + LocalizedStrings.Get("KEYMAPPING_PREFERENCES_RESET_WARNING_informative");
		DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(string.Empty, message, DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.CANCEL);
		if (defaultButtons.HasValue)
		{
			return defaultButtons.Value == DefaultButtons.OK;
		}
		return false;
	}
}
