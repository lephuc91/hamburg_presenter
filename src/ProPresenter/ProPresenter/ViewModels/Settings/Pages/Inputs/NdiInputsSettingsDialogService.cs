using Pro.Common.Dispatcher;
using Pro.Localization.Services;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class NdiInputsSettingsDialogService : INdiInputsSettingsDialogService
{
	private readonly IUiDispatcher _dispatcher;

	private readonly ILocalization _localization;

	public NdiInputsSettingsDialogService(IUiDispatcher uiDispatcher, ILocalization localization)
	{
		_dispatcher = uiDispatcher;
		_localization = localization;
	}

	public void ShowInvalidIpError(string messageContent)
	{
		_dispatcher.Invoke(() => MessageDialogService.ShowSimpleContent(_localization.Get("GLOBAL_INVALID_IP_ADDRESS_ERROR_message"), _localization.Get("GLOBAL_INVALID_IP_ADDRESS_ERROR_info", new object[1] { messageContent })));
	}

	public void ShowInvalidMultiIpError(string messageContent)
	{
		_dispatcher.Invoke(() => MessageDialogService.ShowSimpleContent(_localization.Get("GLOBAL_INVALID_IP_ADDRESS_ERROR_message"), _localization.Get("GLOBAL_INVALID_IP_ADDRESS_MULTIPLE_ERROR_info", new object[1] { messageContent })));
	}
}
