namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public interface INdiInputsSettingsDialogService
{
	void ShowInvalidIpError(string messageContent);

	void ShowInvalidMultiIpError(string messageContent);
}
