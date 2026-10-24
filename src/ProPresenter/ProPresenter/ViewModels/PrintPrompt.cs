using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels;

internal class PrintPrompt : IPrintPrompt
{
	private static readonly string _blankAlertMessage = LocalizedStrings.Get("PRINT_BLANK_PRESENTATION_ALERT_message");

	public void ConfirmPrintingBlank()
	{
		MessageDialogService.ShowAlert(_blankAlertMessage ?? "");
	}
}
