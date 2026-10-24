using Pro.Common.HTTP;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Web;
using ProPresenter.UI.Settings.PageTemplates.Inputs;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class AirCastPrompt : IAirCastPrompt
{
	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IHyperlinkService _hyperlinkService;

	public AirCastPrompt(IWebSourceProvider webSourceProvider, IHyperlinkService hyperlinkService)
	{
		_webSourceProvider = webSourceProvider;
		_hyperlinkService = hyperlinkService;
	}

	public bool ShowConfirmDownload()
	{
		return new ConfirmDownloadAirCastPlugin(_webSourceProvider, _hyperlinkService).ShowDialog() == true;
	}

	public bool ShowDownloadFailed()
	{
		return new AirCastDownloadPluginFailed().ShowDialog() == true;
	}

	public void ShowPasswordRequired()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_INPUTS_NEW_AIRCAST_ALERT_NO_PASSWORD_message"), LocalizedStrings.Get("SETTINGS_INPUTS_NEW_AIRCAST_ALERT_NO_PASSWORD_info"), DefaultButtons.OK, DefaultButtons.OK);
	}
}
