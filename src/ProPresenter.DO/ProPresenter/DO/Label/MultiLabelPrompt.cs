using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.DO.Label;

public class MultiLabelPrompt : ILabelPrompt
{
	public bool ConfirmOverwrite(string? name)
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("PRESENTATION_LABEL_DIALOG_CONFIRM_MUTLIPLE_LABELS_COLOR_CHANGE_message"));
	}
}
