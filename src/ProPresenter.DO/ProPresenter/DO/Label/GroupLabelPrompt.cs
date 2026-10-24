using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.DO.Label;

internal class GroupLabelPrompt : ILabelPrompt
{
	public bool ConfirmOverwrite(string? name)
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("PRESENTATION_LABEL_DIALOG_CONFIRM_GROUP_COLOR_CHANGE_message", new object[1] { name }));
	}
}
