using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Settings.Pages.Network;

public class NetworkDialogService : INetworkDialogService
{
	public void ShowPasswordRequired()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_NETWORK_PROREMOTE_NO_PASSWORD_ALERT_message"), LocalizedStrings.Get("SETTINGS_NETWORK_PROREMOTE_NO_PASSWORD_ALERT_info"), DefaultButtons.OK, DefaultButtons.OK);
	}
}
