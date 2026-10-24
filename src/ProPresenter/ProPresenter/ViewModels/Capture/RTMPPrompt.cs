using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Capture;

public class RTMPPrompt : IRTMPPrompt
{
	public void ShowNoValidCodecAlert()
	{
		MessageDialogService.ShowAlert(LocalizedStrings.Get("SCREEN_CAPTURE_RTMP_INVALID_windows_title"), LocalizedStrings.Get("SCREEN_CAPTURE_RTMP_INVALID_windows_message"));
	}
}
