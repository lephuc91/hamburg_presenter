using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Resi;

public class ResiPrompt : IResiPrompt
{
	public bool ConfirmLogout()
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("RESI_PREFERENCES_UNREGISTER_ALERT_label"));
	}

	public void ShowCustomEndpointsWarning()
	{
		MessageDialogService.ShowAlert(LocalizedStrings.Get("RESI_CUSTOM_URL_ALERT_message"));
	}
}
